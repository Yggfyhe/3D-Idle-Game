using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.InputSystem;

public class DialogueManager : GenericSingleton<DialogueManager>
{
    [Header("대화창")]
    public GameObject talkPanel;
    public TextMeshProUGUI characterNameTxt;
    public TextMeshProUGUI talkText;

    [Header("튜토리얼 장면")]
    public DialogueData tutorialDialogue;
    public IntroSceneEvent introSceneEvent;

    private InputAction leftClickAction;
    private DialogueData currentDialogue; // 현재 대화 데이터
    private int dialogueIndex = 0;        // 현재 대화 인덱스

    private void OnEnable()
    {
        leftClickAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");
        leftClickAction.performed += OnLeftClick;
        leftClickAction.Enable();
    }

    private void OnDisable()
    {
        leftClickAction.performed -= OnLeftClick;
        leftClickAction.Disable();
    }

    private void OnLeftClick(InputAction.CallbackContext context)
    {
        DisplayNextLine();
    }

    // 대화 시작 메서드 (ScriptableObject 대화 데이터를 받아서 초기화)
    public void StartDialogue(DialogueData dialogueData)
    {
        currentDialogue = dialogueData;
        dialogueIndex = 0;
        talkPanel.SetActive(true);
        DisplayNextLine();
    }

    // 대화의 다음 줄을 출력
    public void DisplayNextLine()
    {
        if (currentDialogue == null || dialogueIndex >= currentDialogue.dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        // 현재 대화 내용을 talkText에 표시
        characterNameTxt.text = currentDialogue.characterName;
        talkText.text = currentDialogue.dialogueLines[dialogueIndex];
        dialogueIndex++;
    }

    // 대화 종료 
    private void EndDialogue()
    {
        talkPanel.SetActive(false);

        if (currentDialogue == tutorialDialogue && introSceneEvent != null)
        {
            introSceneEvent.IntroGM();
        }

        currentDialogue = null;
        dialogueIndex = 0;
    }

}


//public class Example : MonoBehaviour
//{
//    public DialogueData tutorialDialogue; <- 튜토리얼 대화 ScriptableObject

//    private void Start()
//    {
//        아래의 함수 사용
//        DialogueManager.Instance.StartDialogue(tutorialDialogue);
//    }
