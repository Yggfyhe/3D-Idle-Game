using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.InputSystem;

public class DialogueManager : GenericSingleton<DialogueManager>
{
    [Header("��ȭâ")]
    public GameObject talkPanel;
    public TextMeshProUGUI characterNameTxt;
    public TextMeshProUGUI talkText;

    [Header("Ʃ�丮�� ���")]
    public DialogueData tutorialDialogue;
    public IntroSceneEvent introSceneEvent;

    private InputAction leftClickAction;
    private DialogueData currentDialogue; // ���� ��ȭ ������
    private int dialogueIndex = 0;        // ���� ��ȭ �ε���

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

    // ��ȭ ���� �޼��� (ScriptableObject ��ȭ �����͸� �޾Ƽ� �ʱ�ȭ)
    public void StartDialogue(DialogueData dialogueData)
    {
        currentDialogue = dialogueData;
        dialogueIndex = 0;
        talkPanel.SetActive(true);
        DisplayNextLine();
    }

    // ��ȭ�� ���� ���� ���
    public void DisplayNextLine()
    {
        if (currentDialogue == null || dialogueIndex >= currentDialogue.dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        // ���� ��ȭ ������ talkText�� ǥ��
        characterNameTxt.text = currentDialogue.characterName;
        talkText.text = currentDialogue.dialogueLines[dialogueIndex];
        dialogueIndex++;
    }

    // ��ȭ ���� 
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
//    public DialogueData tutorialDialogue; <- Ʃ�丮�� ��ȭ ScriptableObject

//    private void Start()
//    {
//        �Ʒ��� �Լ� ���
//        DialogueManager.Instance.StartDialogue(tutorialDialogue);
//    }
