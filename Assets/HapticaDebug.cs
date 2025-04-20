using UnityEngine;
using UnityEngine.InputSystem;

public class HapticaDebug : MonoBehaviour
{
    void Update()
    {
        if (Gamepad.current != null && Gamepad.current.dpad.right.wasPressedThisFrame)
        {
            Debug.Log("➡️ Derecha pulsada");
            Haptica.instance?.Vibrar(0.1f, 0.1f, 0.1f);
        }

        if (Gamepad.current != null && Gamepad.current.dpad.left.wasPressedThisFrame)
        {
            Debug.Log("⬅️ Izquierda pulsada");
            Haptica.instance?.Vibrar(0.1f, 0.1f, 0.1f);
        }
    }
}
