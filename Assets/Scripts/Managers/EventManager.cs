using System;
using System.Collections;
using UnityEngine;

public class EventManager : GenericSingleton<EventManager>
{
    [Header("건물")]
    public GameObject buildingPrefab;

    [Header("메인 캔버스")]
    public CanvasGroup uiCanvasGroup; 
    public float fadeDuration = 1f;

    public void ShowCanvas()
    {
        StartCoroutine(FadeInCanvas());
    }

    public void SummonBuilding()
    {
        Vector3 spawnPosition = new Vector3(-3.14f, 10f, -1.16f);
        Quaternion spawnRotation = Quaternion.Euler(0, -240f, 0);
        Instantiate(buildingPrefab, spawnPosition, spawnRotation);
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
