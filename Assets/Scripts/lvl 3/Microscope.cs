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
        new_sentences[0] = "This seems useful.. maybe i could find some glass slides";
        dialogue.sentences = new_sentences;
    }

    private void OnMouseDown()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
}
