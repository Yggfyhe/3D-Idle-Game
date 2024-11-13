using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/DialogueData", order = 1)]
public class DialogueData : ScriptableObject
{
    public string characterName;
    [TextArea(3, 10)]
    public string[] dialogueLines; 
}
