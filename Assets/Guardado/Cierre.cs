using UnityEngine;
using UnityEngine.EventSystems;

public class Cierre : MonoBehaviour
{
    [Header("GameObject del menú a cerrar")]
    public GameObject menuACerrar;

    [SerializeField] private Canvas menuPrincipal; 

    [Header("Botón que se seleccionará al cerrar")]
    public GameObject botonASeleccionar;

    public void CerrarMenu()
    {
        if (menuACerrar != null)
        {
            menuACerrar.SetActive(false);
        }
        menuPrincipal.enabled = true;
        menuPrincipal.gameObject.SetActive(true);

        if (botonASeleccionar != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(botonASeleccionar);
        }
    }
}
