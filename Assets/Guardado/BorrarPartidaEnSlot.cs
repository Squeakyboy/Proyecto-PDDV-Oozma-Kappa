using UnityEngine;
using System.IO;

public class BorrarSlot : MonoBehaviour
{
    public void Borrar(int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, $"slot{slot}.save");

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"✅ Archivo de guardado slot{slot} eliminado en: {path}");
        }
        else
        {
            Debug.LogWarning($"⚠️ No se encontró el archivo del slot{slot} en: {path}");
        }
    }
}
