using UnityEngine;
using TMPro;
using System.Collections;

public class CargarPartidaDesdeSlot : MonoBehaviour
{
    public TextMeshProUGUI textoCargado; // Asignar en el inspector
    public float duracion = 2f;

    public void CargarPartida(int slot)
    {
        DatosPartida datos = GestorGuardado.CargarDatos(slot);

        if (datos != null)
        {
            VidaPlayer.monedas = datos.monedas;
            VidaPlayer.VidaMaxP = datos.vidaMaxima;
            Disparar.damageExtra = datos.damageExtra;

            Debug.Log("✅ Partida cargada desde el slot " + slot);
            StartCoroutine(MostrarTextoTemporal());
        }
        else
        {
            Debug.LogWarning("⚠️ No hay datos guardados en el slot " + slot);
        }
    }

    private IEnumerator MostrarTextoTemporal()
    {
        if (textoCargado != null)
        {
            textoCargado.gameObject.SetActive(true);
            yield return new WaitForSeconds(duracion);
            textoCargado.gameObject.SetActive(false);
        }
    }
}
