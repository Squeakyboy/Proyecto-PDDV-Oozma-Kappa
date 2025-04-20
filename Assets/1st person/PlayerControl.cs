using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float MouseSensitivity = 2.5f;
    public float JoystickSensitivity = 150f;
    private new Rigidbody rigidbody;
    public Transform MainCamera;
    public static bool juegoPausado = false;

    public float MovementSpeed;
    public float Sensibility;
    public float ExtraSpeed;
    public float JumpForce;
    public int damageHabilidad;

    public static Vector3 position;

    private float verticalRotation = 0f;
    private Vector2 moveInput;
    private Vector2 lookInput;

    private bool Grounded = true;
    private bool isSprinting;
    private bool jumpPressed;
    private bool abilityPressed;

    public GameObject ObjMano;
    public Transform spawn;

    AudioSource audio_Pasos;

    private GameControls controls;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        controls = new GameControls();

        controls.Gameplay.Move.performed += ctx => {
            if (!juegoPausado)
                moveInput = ctx.ReadValue<Vector2>();
        };
        controls.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Gameplay.Look.performed += ctx => {
            if (!juegoPausado)
                lookInput = ctx.ReadValue<Vector2>();
        };
        controls.Gameplay.Look.canceled += ctx => lookInput = Vector2.zero;

        controls.Gameplay.Jump.performed += ctx => jumpPressed = true;
        controls.Gameplay.SpecialAbility.performed += ctx => abilityPressed = true;
        controls.Gameplay.Sprint.performed += ctx => isSprinting = true;
        controls.Gameplay.Sprint.canceled += ctx => isSprinting = false;
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    void Start()
{
    rigidbody = GetComponent<Rigidbody>();
    if (!PlayerControl.juegoPausado)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    audio_Pasos = GetComponent<AudioSource>();
}


    void Update()
    {
        if (juegoPausado) return;

        UpdateMovement();
        UpdateMouseLook();
        Jump();
        Habilidad();

        position = transform.position;
    }

    void UpdateMovement()
    {
        Vector3 direction = (transform.right * moveInput.x + transform.forward * moveInput.y).normalized;
        Vector3 velocity = direction * MovementSpeed;

        if (isSprinting)
            velocity *= ExtraSpeed;

        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;

        audio_Pasos.mute = (moveInput == Vector2.zero);
    }

    void UpdateMouseLook()
    {
        if (lookInput == Vector2.zero || juegoPausado) return;

        bool isGamepad = Gamepad.current != null && Gamepad.current.rightStick.ReadValue() != Vector2.zero;
        float sens = isGamepad ? JoystickSensitivity : MouseSensitivity;

        float mouseX = lookInput.x * sens * Time.deltaTime;
        float mouseY = lookInput.y * sens * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        MainCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        ObjMano.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        ObjMano.transform.localPosition = new Vector3(0.25f, -0.4f, 0.7f);
    }

    void Jump()
    {
        if (jumpPressed && Grounded)
        {
            rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            Grounded = false;
            Haptica.instance?.Vibrar(0.2f, 0.2f, 0.07f);
        }
        jumpPressed = false;
    }

    void Habilidad()
    {
        if (abilityPressed || Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (VidaPlayer.Habilidad >= VidaPlayer.MaxHabilidad)
            {
                foreach (GameObject enemigo in GameObject.FindGameObjectsWithTag("Enemigo"))
                {
                    enemigo.GetComponent<VidaEnemigos>().vida -= damageHabilidad;
                }
                VidaPlayer.Habilidad = 0;
            }
        }
        abilityPressed = false;
    }

    public static void Victoria()
    {
        if (Niveles.nivel <= Niveles.MaxLevel)
            Niveles.MaxLevel++;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void OnCollisionEnter() => Grounded = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Limite"))
            transform.position = spawn.position;
    }
}
