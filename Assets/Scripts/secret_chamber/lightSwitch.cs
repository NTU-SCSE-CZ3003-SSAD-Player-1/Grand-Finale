using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{

    public Animator light_animator;
    public Light lightbulb;
    Dialogue dialogue;
    bool isLightSwitch;
    bool showOnce;

    // Start is called before the first frame update
    void Start()
    {
        isLightSwitch = true;
        dialogue = new Dialogue();
        string[] new_sentences = new string[2];
        new_sentences[0] = "Sounds like something is moving when the lights are off..";
        new_sentences[1] = "Maybe i need something to see in the dark";
        dialogue.sentences = new_sentences;
        showOnce = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        FindObjectOfType<AudioManager>().Play("Switch");
        if (isLightSwitch)
        {
            isLightSwitch = false;
            light_animator.SetBool("IsOn", false);
            lightbulb.intensity = 0;
            FindObjectOfType<AudioManager>().Play("DoorOpen");

            if (!showOnce)
            {
                TriggerDialogue();
                showOnce = true;
            }
            
        }
        else
        {
            isLightSwitch = true;
            light_animator.SetBool("IsOn", true);
            lightbulb.intensity = 1;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
