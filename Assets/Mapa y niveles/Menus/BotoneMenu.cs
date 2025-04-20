using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class BotoneMenu : MonoBehaviour
{

    [SerializeField] public Canvas canvaNiveles;
    [SerializeField] public Canvas canvaDificultad; 
    [SerializeField] public Canvas canvaNav;
    [SerializeField] public Canvas canvaMenu; 
    [SerializeField] public GameObject canvaDatosGuardados; 
    [SerializeField] private GameObject botonPorDefectoNiveles; 
    [SerializeField] private GameObject botonPorDefectoAlCerrarDatos; 
    [SerializeField] private GameObject botonPorDefectoDATOS; 
    [SerializeField] private GameObject botonPorDefectoDificultad; 


    [SerializeField] Animator camAnim;

    public static int zona;

    public static int dificultad;

    // Start is called before the first frame update
    void Start()
    {

        dificultad = 0;

        if (canvaMenu != null || canvaNav != null)
        {
            if (zona == 0)
            {
                canvaNav.enabled = false;
                canvaMenu.enabled = true;
            }
            else
            {
                canvaNav.enabled = true;
                canvaMenu.enabled = false;
            }
        }

        if (canvaNiveles != null) canvaNiveles.enabled = false;
        if (canvaDificultad != null) canvaDificultad.enabled = false;

        if (camAnim != null) camAnim.SetInteger("zona", zona);
    }

    // Update is called once per frame
    void Update()
    {
        bool salir = Input.GetKeyUp(KeyCode.Escape);
        if (salir) Application.Quit();  
    }

  public void SeleccionNivel(int nivel) 
{
    canvaDificultad.enabled = true;
    canvaNiveles.enabled = false;
    canvaMenu.enabled = false;
    canvaDificultad.gameObject.SetActive(true);
    Niveles.nivel = nivel;

   
    if (botonPorDefectoNiveles != null)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonPorDefectoNiveles);
    }

    if (botonPorDefectoDificultad != null)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonPorDefectoDificultad);
    }
}


    public void AbrirGestionDatos()
{
    // Desactivamos otros menús si es necesario
    if (canvaMenu != null) canvaMenu.enabled = false;
    if (canvaNiveles != null) canvaNiveles.enabled = false;
    if (canvaDificultad != null) canvaDificultad.enabled = false;
    

    // Activamos el canvas de datos guardados
    canvaDatosGuardados.SetActive(true);

    if (botonPorDefectoNiveles != null)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonPorDefectoDATOS);
    }
}




    public void Menu(int pantalla)
    {

        Cursor.lockState = CursorLockMode.None;

        if (pantalla > 0) SceneManager.LoadScene("MenuPrincipal");

        else
        {
            camAnim.SetBool("cambio", true);
            canvaMenu.enabled = false;

        }
    }

    public void Navegacion(int origen)  
    {

        camAnim.SetBool("cambio", true);  
    }

    public void Ajustes()
    {
        SceneManager.LoadScene("Ajustes"); 
    }

    public void Tienda() 
    {
        SceneManager.LoadScene("Tienda");
    }

    public void NivelesMenu()
{
    canvaNiveles.enabled = true;
    canvaNav.enabled = false;
    canvaMenu.enabled = false;
    canvaNiveles.gameObject.SetActive(true);


    if (botonPorDefectoNiveles != null)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonPorDefectoNiveles);
    }
}


    public void Dificultad(int dif) 
    {

        dificultad = dif;

        Cursor.lockState = CursorLockMode.Locked;
        canvaDificultad.gameObject.SetActive(true);  
        canvaDificultad.enabled = true;              



    if (botonPorDefectoDificultad != null)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonPorDefectoDificultad);
    }

        switch (Niveles.nivel)
        {
            case 0:
                SceneManager.LoadScene("Nivel 1");
                break;
            case 1:
                SceneManager.LoadScene("Nivel 2");
                break;
            case 2:
                SceneManager.LoadScene("Nivel 3");
                break;
            default: break;
        }
    }

    public void cambioZona()
    {
        if (camAnim.GetInteger("zona") == 1)
        {
             canvaNiveles.enabled = false;
             canvaNav.enabled = true;
             canvaMenu.enabled = false;
        }
        else
        {
            canvaNiveles.enabled = false;
            canvaNav.enabled = false;
            canvaMenu.enabled = true;
        }
    }

    
}

