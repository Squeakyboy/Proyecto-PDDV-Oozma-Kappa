using UnityEngine;
using UnityEngine.EventSystems;

public class AutoSelectUI : MonoBehaviour
{
    public GameObject botonInicial;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonInicial);
    }

    void Update()
{
    if (EventSystem.current.currentSelectedGameObject != null)
        Debug.Log("Botón seleccionado: " + EventSystem.current.currentSelectedGameObject.name);
}

}
