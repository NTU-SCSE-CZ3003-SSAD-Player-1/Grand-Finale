using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{

    Dialogue dialogue;

    void Start()
    {
        Item.buttonClickDelegateItem += OnInteract;
        dialogue = new Dialogue();
        string[] new_sentences = new string[2];
        new_sentences[0] = "This document talks about an experiment on human behaviour placed under stress...";
        new_sentences[1] = "\"Humans under high level of stress may develop special abilities....? \"";
        dialogue.sentences = new_sentences;
    }


    void Update()
    {

    }

    void OnInteract(string gameObjectName)
    {
        if (gameObjectName == "Book")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    void OnDisable()
    {
        Item.buttonClickDelegateItem -= OnInteract;
    }
}
