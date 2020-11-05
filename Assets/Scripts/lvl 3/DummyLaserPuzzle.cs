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
        new_sentences[0] = "hmmmm... this looks playable";
        new_sentences[1] = "I think it needs some kind of laser to trigger the game";
        dialogue.sentences = new_sentences;
    }

    private void OnMouseDown()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
}
