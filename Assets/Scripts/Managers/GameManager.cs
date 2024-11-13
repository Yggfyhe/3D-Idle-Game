using System;
using System.Collections;
using UnityChan;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    [Header("인트로 장면")]
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
        yield return new WaitForSeconds(4f);
        DialogueManager.Instance.StartDialogue(DialogueManager.Instance.tutorialDialogue);
    }
}
