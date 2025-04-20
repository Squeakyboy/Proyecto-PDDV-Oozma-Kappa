using UnityEngine;
using UnityEngine.UI;
using TMPro; // Si usas TextMeshPro

public class BotonGuardado : MonoBehaviour
{
    public int slotID; // Asignar manualmente en el inspector (1, 2 o 3)
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoVida;
    public TextMeshProUGUI textoDamage;
    public TextMeshProUGUI textoEstado; // Puede decir "VACÍO" o "OCUPADO"

    void Start()
    {
        ActualizarVisual();
    }

    public void ActualizarVisual()
    {
        DatosPartida datos = GestorGuardado.CargarDatos(slotID);

        if (datos != null)
        {
            textoEstado.text = "OCUPADO";
            textoMonedas.text = "Monedas: " + datos.monedas;
            textoVida.text = "Vida: " + datos.vidaMaxima;
            textoDamage.text = "Daño: " + datos.damageExtra;
        }
        else
        {
            textoEstado.text = "VACÍO";
            textoMonedas.text = "";
            textoVida.text = "";
            textoDamage.text = "";
        }
    }
}
