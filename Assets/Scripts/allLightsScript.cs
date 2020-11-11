using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allLightsScript : MonoBehaviour
{
    public Pieces pieces;
    public Light lightbulb1;
    public Light lightbulb2;
    public Light lightbulb3;
    Dialogue dialogue;
    bool showOnce;
    // Start is called before the first frame update
    void Start()
    {
        showOnce = false;
        dialogue = new Dialogue();
        string[] new_sentences = new string[2];
        new_sentences[0] = "I can't see.";
        new_sentences[1] = "Maybe I need something to see in the dark";
        dialogue.sentences = new_sentences;
        lightbulb1.intensity = 0;
        lightbulb2.intensity = 0;
        lightbulb3.intensity = 0;
        if (!showOnce)
            {
                TriggerDialogue();
                showOnce = true;
            }
        Pieces.onFinish += something;
    }

    

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void something(){
         Debug.Log("updated value"); 
        lightbulb1.intensity = 1;
        lightbulb2.intensity = 1;
        lightbulb3.intensity = 1;
    }

    private void OnDestroy()
    {
        Pieces.onFinish -= something;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}