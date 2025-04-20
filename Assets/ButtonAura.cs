using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAura : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject aura;

    public void OnSelect(BaseEventData eventData)
    {
        aura.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        aura.SetActive(false);
    }
}
