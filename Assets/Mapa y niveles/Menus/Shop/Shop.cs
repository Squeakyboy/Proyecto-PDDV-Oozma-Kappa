using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField] List<Item> items;

    [SerializeField] ContadorMuertes ContadorMonedas;
    [SerializeField] ContadorMuertes ContadorVida;
    [SerializeField] ContadorMuertes ContadorDamage;
    [SerializeField] private SpeechBubblePopWiggle tendero;

    void Start()
    {
        tendero = FindObjectOfType<SpeechBubblePopWiggle>();

        if (tendero == null)
            Debug.LogWarning("❌ Tendero no encontrado en la escena.");
        else
            Debug.Log("✅ Tendero encontrado correctamente.");
    }

    void Update()
    {
        // Actualizar contadores cada frame
        ContadorMonedas.cont = VidaPlayer.monedas;
        ContadorVida.cont = VidaPlayer.VidaMaxP;
        ContadorDamage.cont = Disparar.damageExtra;

        // Salir de la tienda (Escape o Botón Círculo)
        bool salirTeclado = Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame;
        bool salirMando = Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame;

        if (salirTeclado || salirMando)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    public void comprar(int producto)
    {
        if (VidaPlayer.monedas >= items[producto].precio)
        {
            VidaPlayer.monedas -= items[producto].precio;

            // Actualizar contadores
            ContadorMonedas.cont = VidaPlayer.monedas;
            ContadorVida.cont = VidaPlayer.VidaMaxP;
            ContadorDamage.cont = Disparar.damageExtra;

            // Añadir al inventario (sin límite de compras)
            Inventario.items.Add(items[producto]);

            // Mostrar animación de compra
            if (tendero != null)
            {
                Debug.Log("🎉 Animación de compra activada");
                tendero.ShowBubble();
            }

            Debug.Log("✅ ¡Compra realizada de producto: " + producto + "!");
        }
        else
        {
            MostrarFeedbackSinMonedas();
        }
    }

    private void MostrarFeedbackSinMonedas()
    {
        Debug.Log("❌ No tienes suficientes monedas.");

        if (tendero != null)
        {
            Debug.Log("🔔 Mostrando burbuja de error");
            tendero.ShowBubble();
        }
    }
}
