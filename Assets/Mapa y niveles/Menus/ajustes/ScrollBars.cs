using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollBarDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDragging = false;

    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Slider scrollbar;

    private void Start()
    {
        scrollbar = GetComponent<Slider>();
    }
    void Update()
    {
        if (isDragging)
        {
            // Mueve la barra con la posición del ratón
            Vector2 mousePos = Input.mousePosition;
            scrollbar.value = Mathf.Clamp01(mousePos.x / Screen.width);

            text.text = scrollbar.value.ToString();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void ComprobarValor() 
    {
        text.text = scrollbar.value.ToString();
    }
}
