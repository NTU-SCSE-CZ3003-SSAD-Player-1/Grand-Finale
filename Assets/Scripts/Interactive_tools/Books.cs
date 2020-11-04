using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour
{
    Dialogue dialogue;

    void Start()
    {
        Item.buttonClickDelegateItem += OnInteract;
        dialogue = new Dialogue();
        string[] new_sentences = new string[2];
        new_sentences[0] = "\"Putting humans in a trapped and repetitive environment produces stress...\"";
        new_sentences[1] = "\"Reducing time of the challenge also intensify the stress..\"";
        dialogue.sentences = new_sentences;
    }


    void Update()
    {

    }

    void OnInteract(string gameObjectName)
    {
        if (gameObjectName == "Books")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    void OnDisable()
    {
        Item.buttonClickDelegateItem -= OnInteract;
    }
}
