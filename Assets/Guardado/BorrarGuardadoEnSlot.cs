using UnityEngine;

public class BorrarGuardadoEnSlot : MonoBehaviour
{
    public int slotID; // Asignar manualmente en el inspector (1, 2 o 3)
    public BotonGuardado botonVisual; // Asigna el BotonGuardado correspondiente

    public void BorrarDatos()
    {
        string ruta = GestorGuardado.ObtenerRuta(slotID);

        if (System.IO.File.Exists(ruta))
        {
            System.IO.File.Delete(ruta);
            Debug.Log($"🗑️ Datos del slot {slotID} eliminados.");

            if (botonVisual != null)
                botonVisual.ActualizarVisual();
        }
        else
        {
            Debug.LogWarning($"⚠️ No hay datos para borrar en el slot {slotID}.");
        }
    }
}
