using UnityEngine;

public class DebugFocusable : MonoBehaviour, IFocusable
{
    public Color highlightColor = Color.white;
    private Color originalColor;
    private MeshRenderer meshRenderer;
    private Material material;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            material = meshRenderer.material;
            
        }
    }

    public void Focus(GameObject interactor)
    {
        if (material != null)
        {
            originalColor = material.GetColor("_EmissionColor");
            material.SetColor("_EmissionColor", highlightColor);
            material.EnableKeyword("_EMISSION");
        }
    }

    public void Unfocus(GameObject interactor)
    {
        if (material != null)
        {
            material.SetColor("_EmissionColor", originalColor);
            material.DisableKeyword("_EMISSION");
        }
    }
}

