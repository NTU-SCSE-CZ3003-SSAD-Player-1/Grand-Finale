
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public Item item;
    public Dialogue dialogue;
    bool firstInteract;

    public Dialogue Dialogue
    {
        get => dialogue;
        set => dialogue = value;
    }

    public Item Item
    {
        get => item;
    }

    public bool FirstInteract
    {
        get => firstInteract;
        set => firstInteract = value;
    }

    private void OnMouseDown()
    {
        OnInteract();
    }

    public virtual void OnInteract()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
