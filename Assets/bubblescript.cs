using System.Collections;
using UnityEngine;

public class SpeechBubblePopWiggle : MonoBehaviour
{
    public GameObject bubbleRoot;
    public Transform shadow;
    public Transform fill;
    public Transform outline;

    public float wiggleInterval = 0.1f;
    public float wiggleAngle = 5f;

    public float popDuration = 0.3f;
    public float visibleDuration = 2f;

    private bool isActive = false;

    private Vector3 originalScale;

    void Start()
    {
        bubbleRoot.SetActive(false);
        originalScale = bubbleRoot.transform.localScale;
    }

    public void ShowBubble()
    {
        StopAllCoroutines();
        StartCoroutine(ShowAndAnimate());
    }

    private IEnumerator ShowAndAnimate()
    {
        // RESET
        bubbleRoot.SetActive(true);
        shadow.localRotation = Quaternion.identity;
        fill.localRotation = Quaternion.identity;
        outline.localRotation = Quaternion.identity;

        // POP: escala de 0 a 1 con rebote
        bubbleRoot.transform.localScale = Vector3.zero;

        float t = 0f;
        while (t < popDuration)
        {
            t += Time.deltaTime;
            float scale = EaseOutBack(t / popDuration); // con rebote
            bubbleRoot.transform.localScale = originalScale * scale;

            yield return null;
        }
        bubbleRoot.transform.localScale = originalScale;

        isActive = true;
        StartCoroutine(Wiggle());

        yield return new WaitForSeconds(visibleDuration);

        isActive = false;
        bubbleRoot.SetActive(false);
        bubbleRoot.transform.localScale = Vector3.one;
    }

    private IEnumerator Wiggle()
    {
        while (isActive)
        {
            float angle1 = Random.Range(-wiggleAngle, wiggleAngle);
            float angle2 = Random.Range(-wiggleAngle, wiggleAngle);
            float angle3 = Random.Range(-wiggleAngle, wiggleAngle);

            shadow.localRotation = Quaternion.Euler(0, 0, angle1);
            fill.localRotation = Quaternion.Euler(0, 0, angle2);
            outline.localRotation = Quaternion.Euler(0, 0, angle3);

            yield return new WaitForSeconds(wiggleInterval);
        }

        // Reset rotaciones
        shadow.localRotation = Quaternion.identity;
        fill.localRotation = Quaternion.identity;
        outline.localRotation = Quaternion.identity;
    }

    // Función de rebote suave (ease out back)
    private float EaseOutBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1f;
        return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }
}
