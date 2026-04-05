using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverTextEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Hover Settings")]
    public Color normalColor = Color.white;
    public Color hoverColor = Color.white;
    public float hoverScale = 1.1f;

    [Header("Bold Settings")]
    public bool useBoldOnHover = true;

    private TextMeshProUGUI textMesh;
    private Vector3 originalScale;
    private FontStyles originalFontStyle;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalScale = transform.localScale;
        originalFontStyle = textMesh.fontStyle;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMesh.color = hoverColor;
        transform.localScale = originalScale * hoverScale;

        if (useBoldOnHover)
        {
            textMesh.fontStyle = originalFontStyle | FontStyles.Bold;
            textMesh.ForceMeshUpdate();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMesh.color = normalColor;
        transform.localScale = originalScale;

        if (useBoldOnHover)
        {
            textMesh.fontStyle = originalFontStyle;
            textMesh.ForceMeshUpdate();
        }
    }
}