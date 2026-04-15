using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SmoothButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Sprites")]
    public Sprite normalSprite;
    public Sprite hoverSprite;

    [Header("Transition Settings")]
    [Tooltip("Higher = faster transition (like Unity default)")]
    public float transitionSpeed = 5f;

    private Image buttonImage;

    private Coroutine transitionCoroutine;
    private Color originalColor;

    void Awake()
    {
        buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;

        if (normalSprite != null)
            buttonImage.sprite = normalSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartSpriteTransition(hoverSprite);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartSpriteTransition(normalSprite);
    }

    private void StartSpriteTransition(Sprite targetSprite)
    {
        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);

        transitionCoroutine = StartCoroutine(FadeToSprite(targetSprite));
    }

    private IEnumerator FadeToSprite(Sprite targetSprite)
    {
        Sprite currentSprite = buttonImage.sprite;

        if (currentSprite == targetSprite)
        {
            buttonImage.color = originalColor;
            yield break;
        }

        float elapsed = 0f;
        Color startColor = buttonImage.color;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * transitionSpeed * 1.5f;
            float t = Mathf.Clamp01(elapsed);

            Color c = startColor;
            c.a = Mathf.Lerp(startColor.a, 0f, t);
            buttonImage.color = c;
            yield return null;
        }

        buttonImage.sprite = targetSprite;

        elapsed = 0f;
        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * transitionSpeed;
            float t = Mathf.Clamp01(elapsed);

            Color c = originalColor;
            c.a = Mathf.Lerp(0f, originalColor.a, t);
            buttonImage.color = c;
            yield return null;
        }

        buttonImage.color = originalColor;
    }
}