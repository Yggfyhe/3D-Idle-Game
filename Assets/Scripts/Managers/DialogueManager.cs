using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;
using KoreanTyper;
using UnityEngine.UI;


public class DialogueManager : GenericSingleton<DialogueManager>
{
    [Header("��ȭâ")]
    public GameObject talkPanel;
    public TextMeshProUGUI characterNameTxt;
    public TextMeshProUGUI talkText;
    //public Text[] TestTexts;

    [Header("Ʃ�丮�� ���")]
    public DialogueData tutorialDialogue;
    public IntroSceneEvent introSceneEvent;

    private InputAction leftClickAction;
    private DialogueData currentDialogue; // ���� ��ȭ ������
    private int dialogueIndex = 0;        // ���� ��ȭ �ε���
    private Coroutine typingCoroutine;

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
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypingText());
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

    public IEnumerator TypingText()
    {
        talkText.text = "";

        string currentLine = currentDialogue.dialogueLines[dialogueIndex];
        int strTypingLength = currentLine.GetTypingLength();

        for (int i = 0; i <= strTypingLength; i++)
        {
            talkText.text = currentLine.Typing(i);
            yield return new WaitForSeconds(0.03f); // Ÿ���� �ӵ� ����
        }

        yield return new WaitForSeconds(1f);

        //while (true)
        //{
        //    string[] strings = new string[1] {currentDialogue.dialogueLines[dialogueIndex]};
        //    foreach (Text t in TestTexts)
        //        t.text = "";

        //    for (int t = 0; t < TestTexts.Length && t < strings.Length; t++)
        //    {
        //        int strTypingLength = strings[t].GetTypingLength();

        //        for (int i = 0; i <= strTypingLength; i++)
        //        {
        //            TestTexts[t].text = strings[t].Typing(i);
        //            yield return new WaitForSeconds(0.03f);
        //        }
        //        yield return new WaitForSeconds(1f);
        //    }
        //    yield return new WaitForSeconds(1f);
        //}
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
