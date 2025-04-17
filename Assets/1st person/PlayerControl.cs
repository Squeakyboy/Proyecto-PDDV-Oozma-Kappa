using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    private new Rigidbody rigidbody;

    public float MovementSpeed;

    public float Sensibility;

    public float ExtraSpeed;
    public float JumpForce;

    public int damageHabilidad;

    public static Vector3 position;

    bool IsJump = false;
    bool Grounded = true;

    public GameObject ObjMano;

    public Transform spawn;

    bool salir;

    AudioSource audio_Pasos;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        audio_Pasos = GetComponent<AudioSource>();

    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void UpdateMovement()
    {
        position = transform.position;
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        float Shift = Input.GetAxisRaw("Run");

        Vector3 velocity = Vector3.zero;

        if ((Horizontal != 0) || (Vertical != 0))
        {
            Vector3 direction = (transform.right * Horizontal + transform.forward * Vertical).normalized;
            velocity = direction * MovementSpeed;

            if (Shift != 0)
            {
                velocity *= ExtraSpeed;
            }

            audio_Pasos.mute = false;

        }
        else audio_Pasos.mute = true;

        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }

    void UpdateMouseLook()
    {

        float Horizontal_Look = Input.GetAxis("Mouse X");

        if (Horizontal_Look != 0)
        {
            transform.Rotate(0, Horizontal_Look * Sensibility, 0);
        }
    }

    void Jump()
    {
        IsJump = Input.GetButtonDown("Jump");
        if (IsJump && Grounded)
        {
            rigidbody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            Grounded = false;
        }
    }

    void Habilidad() 
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (VidaPlayer.Habilidad >= VidaPlayer.MaxHabilidad) 
            {
                GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

                for (int i = 0; i < enemigos.Length; i++) 
                {
                    enemigos[i].GetComponent<VidaEnemigos>().vida -= damageHabilidad;
                }

                VidaPlayer.Habilidad = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        UpdateMovement();
        UpdateMouseLook();
        Jump();
        Habilidad();

        salir = Input.GetKeyDown(KeyCode.C); 

        if (salir) 
        {
            Cursor.lockState = CursorLockMode.None; 
            SceneManager.LoadScene("MenuPrincipal"); 
        }
    }

    public static void Victoria() 
    {
        if (Niveles.nivel <= Niveles.MaxLevel) 
        {
            Niveles.MaxLevel++;
        }
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MenuPrincipal");
    }

    void DestroyAllWithTag(string tag)
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }

    private void OnCollisionEnter()
    {
        Grounded = true;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Limite")
        {
            transform.position = spawn.position;
        }

    }
}
