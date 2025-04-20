using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MandoDetectorUI : MonoBehaviour
{
    [Header("Animaciones temporales")]
    public GameObject[] objetosConectado;
    public GameObject[] objetosDesconectado;

    [Header("Siempre visibles si hay mando")]
    public GameObject[] objetosMandoActivo;

    public float fadeDuration = 0.5f;
    public float visibleDuration = 2f;

    private void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
        CheckEstadoInicial();
    }

    private void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    private void CheckEstadoInicial()
    {
        bool hayMando = Gamepad.all.Count > 0;
        ActivarObjetos(objetosMandoActivo, hayMando);
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (device is Gamepad)
        {
            if (change == InputDeviceChange.Added)
            {
                foreach (var obj in objetosConectado)
                {
                    StartCoroutine(MostrarTransicion(obj));
                }
                ActivarObjetos(objetosMandoActivo, true);
            }
            else if (change == InputDeviceChange.Removed || change == InputDeviceChange.Disconnected)
            {
                foreach (var obj in objetosDesconectado)
                {
                    StartCoroutine(MostrarTransicion(obj));
                }

                if (Gamepad.all.Count == 0)
                {
                    ActivarObjetos(objetosMandoActivo, false);
                }
            }
        }
    }

    private void ActivarObjetos(GameObject[] objetos, bool estado)
    {
        foreach (var obj in objetos)
        {
            if (obj != null)
                obj.SetActive(estado);
        }
    }

    private IEnumerator MostrarTransicion(GameObject imagen)
    {
        if (imagen == null) yield break;

        imagen.SetActive(true);
        CanvasGroup cg = imagen.GetComponent<CanvasGroup>();
        if (cg == null) yield break;

        cg.alpha = 0f;

        // Fade in
        float timer = 0f;
        while (timer < fadeDuration)
        {
            cg.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        cg.alpha = 1f;

        // Visible por X segundos
        yield return new WaitForSeconds(visibleDuration);

        // Fade out
        timer = 0f;
        while (timer < fadeDuration)
        {
            cg.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        cg.alpha = 0f;
        imagen.SetActive(false);
    }
}
