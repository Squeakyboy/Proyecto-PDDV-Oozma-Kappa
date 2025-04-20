using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorTiendaConMando : MonoBehaviour
{
    [Header("Objetos de la tienda")]
    public HoverItemPreviewSmooth objetoIzquierda;
    public HoverItemPreviewSmooth objetoDerecha;

    private int indexSeleccionado = 0; // 0 = izquierda, 1 = derecha
    private HoverItemPreviewSmooth[] objetos;
    private bool puedeMover = true;

    private Shop shop; // 🔁 Referencia al script Shop

    private void Start()
    {
        objetos = new HoverItemPreviewSmooth[] { objetoIzquierda, objetoDerecha };
        SeleccionarObjeto(1); // empezar por la derecha

        shop = FindObjectOfType<Shop>(); // 🟢 buscar la tienda en escena

        if (shop == null)
            Debug.LogWarning("❌ No se encontró el script Shop en escena.");
    }

    private void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) return;

        Vector2 input = gamepad.leftStick.ReadValue();
        Vector2 dpad = gamepad.dpad.ReadValue();
        float horizontal = input.x + dpad.x;  // combinas cruceta + joystick

        // Evita moverse varias veces por mantener pulsado
        if (puedeMover)
        {
            if (horizontal > 0.5f)
            {
                CambiarSeleccion(1); // derecha
            }
            else if (horizontal < -0.5f)
            {
                CambiarSeleccion(0); // izquierda
            }
        }

        puedeMover = Mathf.Abs(horizontal) < 0.5f;

        // Confirmar con botón X / A
        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            Debug.Log("Presionado botón X/A");

            if (indexSeleccionado >= 0 && indexSeleccionado < objetos.Length)
            {
                ComprarObjeto(indexSeleccionado);
            }
        }
    }

    void CambiarSeleccion(int nuevoIndex)
    {
        if (nuevoIndex == indexSeleccionado) return;

        objetos[indexSeleccionado].ForzarHover(false); // desactiva anterior
        indexSeleccionado = nuevoIndex;
        objetos[indexSeleccionado].ForzarHover(true);  // activa nuevo
        Haptica.instance?.Vibrar(0.03f, 0.03f, 0.03f);

    }

    void SeleccionarObjeto(int index)
    {
        objetos[0].ForzarHover(false);
        objetos[1].ForzarHover(false);
        objetos[index].ForzarHover(true);
        indexSeleccionado = index;
    }

    void ComprarObjeto(int index)
    {
        Debug.Log("🛒 Intentando comprar con el mando: " + objetos[index].name);

        if (shop != null)
        {
            shop.comprar(index); // ✅ Llama al método del sistema real de compras
        }
        else
        {
            Debug.LogWarning("❌ No se puede comprar, Shop no asignado");
        }
    }
}
