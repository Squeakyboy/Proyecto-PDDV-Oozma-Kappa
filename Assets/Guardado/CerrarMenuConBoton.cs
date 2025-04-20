using UnityEngine;
using UnityEngine.EventSystems;

public class CerrarMenuConBoton : MonoBehaviour
{
    [Header("GameObject del menú a cerrar")]
    public GameObject menuACerrar;

    [Header("Botón que se seleccionará al cerrar")]
    public GameObject botonASeleccionar;

    public void CerrarMenu()
    {
        if (menuACerrar != null)
        {
            menuACerrar.SetActive(false);
        }

        if (botonASeleccionar != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(botonASeleccionar);
        }
    }
}
