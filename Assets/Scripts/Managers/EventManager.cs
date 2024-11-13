using System;
using System.Collections;
using UnityEngine;

public class EventManager : GenericSingleton<EventManager>
{
    [Header("¸ÞÀÎ Äµ¹ö½º")]
    public CanvasGroup uiCanvasGroup; 
    public float fadeDuration = 1f;

    public void ShowCanvas()
    {
        StartCoroutine(FadeInCanvas());
    }

    private IEnumerator FadeInCanvas()
    {
        uiCanvasGroup.alpha = 0f;
        uiCanvasGroup.gameObject.SetActive(true);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            uiCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        uiCanvasGroup.alpha = 1f;
    }
}
