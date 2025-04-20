using UnityEngine;
using UnityEngine.EventSystems;

public class HoverItemTriggerFromUI : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public HoverItemPreviewSmooth hoverScript;

    public void OnSelect(BaseEventData eventData)
    {
        if (hoverScript != null)
        {
            hoverScript.ForzarHover(true);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (hoverScript != null)
        {
            hoverScript.ForzarHover(false);
        }
    }
}
