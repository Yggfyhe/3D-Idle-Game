using System;
using System.Collections;
using UnityChan;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    public VirtualCameraController VirtualCameraController;
    public TitleCanvasUI TitleCanvas;

    public void StartGame()
    {
        StartCoroutine(StartGameSequence());
    }

    private IEnumerator StartGameSequence()
    {
        yield return StartCoroutine(TitleCanvas.FadeOut());
        yield return StartCoroutine(VirtualCameraController.IntroCamera());

    }
}
