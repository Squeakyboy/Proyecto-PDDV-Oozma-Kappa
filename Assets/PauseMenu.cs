using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject controlesPanel;
    public GameObject hudCanvas;
    public GameObject botonReanudar;
    public GameObject pauseCanvas;       // Canvas de pausa
    public GameObject controlesCanvas;   // Canvas de controles
    public GameObject botonVolverControles;



    private bool isPaused = false;
    private GameControls controls;

    private void Awake()
    {
        controls = new GameControls();
        controls.Gameplay.Pause.performed += ctx => TogglePause();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void TogglePause()
    {
        if (isPaused)
            ReanudarJuego();
        else
            PausarJuego();
    }

    public void PausarJuego()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if (hudCanvas) hudCanvas.SetActive(false);
        pausePanel.SetActive(true);
        controlesPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 💡 Aquí usamos una corrutina para asegurar que el botón se selecciona correctamente
        StartCoroutine(SeleccionarBoton(botonReanudar));
    }

    public void ReanudarJuego()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (hudCanvas) hudCanvas.SetActive(true);
        pausePanel.SetActive(false);
        controlesPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Limpiar selección actual
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void MostrarControles()
{
    controlesCanvas.SetActive(true);
    pauseCanvas.SetActive(false);

    StartCoroutine(SeleccionarBoton(botonVolverControles));
}


    public void GuardarJuego()
    {
        Debug.Log("Juego guardado (simulado)");
    }

    public void CerrarControles()
{
    controlesCanvas.SetActive(false);
    pauseCanvas.SetActive(true);

    StartCoroutine(SeleccionarBoton(botonReanudar));
}


    public void VolverAlMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    // ✅ Corrutina para asegurar que el botón se selecciona correctamente después de habilitar el Canvas
    private System.Collections.IEnumerator SeleccionarBoton(GameObject boton)
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(boton);
    }
}
