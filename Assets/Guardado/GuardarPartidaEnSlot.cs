using UnityEngine;
using System.Collections;

public class GuardarPartidaEnSlot : MonoBehaviour
{
    public BotonGuardado[] botonesSlots; // Asigna los botones en el Inspector

    // Este método se llama cuando quieres guardar en un slot (por ejemplo al pulsar un botón)
    public void GuardarPartida(int slot)
    {
        DatosPartida datos = new DatosPartida
        {
            monedas = VidaPlayer.monedas,
            vidaMaxima = VidaPlayer.VidaMaxP,
            damageExtra = Disparar.damageExtra
        };

        GestorGuardado.GuardarDatos(datos, slot);

        // Refrescar los datos mostrados en los botones
        foreach (var boton in botonesSlots)
        {
            if (boton.slotID == slot)
            {
                boton.ActualizarVisual();
            }
        }

        Debug.Log("✅ Partida guardada en el slot " + slot);
        Debug.Log("📁 Guardados en: " + Application.persistentDataPath);

    }
}
