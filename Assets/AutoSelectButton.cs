using UnityEngine;
using UnityEngine.EventSystems;

public class AutoSelectButton : MonoBehaviour
{
    public GameObject firstButton;

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
