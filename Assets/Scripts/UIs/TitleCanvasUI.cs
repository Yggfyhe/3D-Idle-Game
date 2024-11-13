using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCanvasUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private float fadeDuration = 1f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public IEnumerator FadeOut()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.gameObject.SetActive(false); 
    }
}
