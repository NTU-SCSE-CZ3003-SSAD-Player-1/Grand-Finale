using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyLaserPuzzle : MonoBehaviour
{
    Dialogue dialogue;

    void Start()
    {
        dialogue = new Dialogue();
        string[] new_sentences = new string[2];
        new_sentences[0] = "This looks like a strange puzzle..";
        new_sentences[1] = "I think it needs some kind of laser for it to work";
        dialogue.sentences = new_sentences;
    }

    private void OnMouseDown()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
}
