using UnityEngine;
using UnityEngine.EventSystems;

public class HapticaMenu : MonoBehaviour
{
    private GameObject botonAnterior;

    void Update()
    {
        GameObject botonActual = EventSystem.current.currentSelectedGameObject;

        if (botonActual != null && botonActual != botonAnterior)
        {
            // Vibrar al cambiar de botón
            if (Haptica.instance != null)
                Haptica.instance.Vibrar(0.01f, 0.01f, 0.02f);

            botonAnterior = botonActual;
        }
    }
}
