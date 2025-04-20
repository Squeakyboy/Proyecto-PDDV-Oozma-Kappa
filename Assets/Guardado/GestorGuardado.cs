using UnityEngine;
using System.IO;

public static class GestorGuardado
{
    public static void GuardarDatos(DatosPartida datos, int slot)
    {
        string ruta = ObtenerRuta(slot);
        string json = JsonUtility.ToJson(datos);
        File.WriteAllText(ruta, json);
        Debug.Log("✅ Guardado en slot " + slot);
    }

    public static DatosPartida CargarDatos(int slot)
    {
        string ruta = ObtenerRuta(slot);
        if (File.Exists(ruta))
        {
            string json = File.ReadAllText(ruta);
            DatosPartida datos = JsonUtility.FromJson<DatosPartida>(json);
            Debug.Log("📂 Datos cargados del slot " + slot);
            return datos;
        }
        else
        {
            Debug.LogWarning("❌ No se encontró el archivo del slot " + slot);
            return null;
        }
    }

    public static string ObtenerRuta(int slot)
    {
        return Application.persistentDataPath + "/partida_slot_" + slot + ".json";
    }
}
