using UnityEngine;

public class OutlineController : MonoBehaviour
{
    [SerializeField] private Color outlineColor = Color.yellow;
    [SerializeField] private float outlineWidth = 0.03f;

    private Material originalMaterial;
    private Material outlineMaterial;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponentInChildren<Renderer>();

        // Validación crítica: Si no hay Renderer, desactiva el script
        if (objectRenderer == null)
        {
            Debug.LogError("No hay Renderer en el objeto o sus hijos: " + gameObject.name);
            enabled = false; // Desactiva este script
            return;
        }

        Shader outlineShader = Shader.Find("Custom/OutlineV2");
        if (outlineShader == null)
        {
            Debug.LogError("El shader 'Custom/OutlineV2' no existe");
            enabled = false;
            return;
        }

        originalMaterial = objectRenderer.material;
        outlineMaterial = new Material(outlineShader);
        outlineMaterial.CopyPropertiesFromMaterial(originalMaterial);
        outlineMaterial.SetColor("_OutlineColor", outlineColor);
        outlineMaterial.SetFloat("_OutlineWidth", 0);

        objectRenderer.material = outlineMaterial;
        objectRenderer = GetComponentInChildren<Renderer>();
       
        outlineMaterial = new Material(Shader.Find("Custom/OutlineV2")); // Nueva instancia
        outlineMaterial.SetFloat("_OutlineWidth", 0); // Iniciar en 0
    }

    void OnMouseEnter()
    {
        if (outlineMaterial != null)
        { // Validación añadida
            outlineMaterial.SetFloat("_OutlineWidth", outlineWidth);
      

                Debug.Log("RATÓN ENCIMA"); // ¿Aparece este mensaje?
                                           // ...
            
        }
    }

    void OnMouseExit()
    {
        if (outlineMaterial != null)
        { // Validación añadida (línea 32)
            outlineMaterial.SetFloat("_OutlineWidth", 0);
        }
    }

    void OnDestroy()
    {
        // Destruye el material solo si el juego está en ejecución
        if (outlineMaterial != null && Application.isPlaying)
        {
            Destroy(outlineMaterial);
        }
    }

    void OnDisable()
    {
        // Restaura el material original si el script se desactiva
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }
    }
}