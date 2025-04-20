using UnityEngine;
using UnityEngine.InputSystem;

public class Haptica : MonoBehaviour
{
    public static Haptica instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void Vibrar(float lowIntensity, float highIntensity, float duration)
    {
        if (Gamepad.current == null) return;

        Gamepad.current.SetMotorSpeeds(lowIntensity, highIntensity);
        CancelInvoke(nameof(PararVibracion));
        Invoke(nameof(PararVibracion), duration);
    }

    private void PararVibracion()
    {
        if (Gamepad.current != null)
            Gamepad.current.SetMotorSpeeds(0f, 0f);
    }
}
