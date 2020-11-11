using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microscope : MonoBehaviour
{
    Dialogue dialogue;

    void Start()
    {
        dialogue = new Dialogue();
        string[] new_sentences = new string[1];
        new_sentences[0] = "This seems useful.. Maybe there are more glass slides around.";
        dialogue.sentences = new_sentences;
    }

    private void OnMouseDown()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
}
