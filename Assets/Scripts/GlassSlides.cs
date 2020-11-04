using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSlides : MonoBehaviour
{
    public enum SlidesColour
    {
        RED,
        BLUE,
        GREEN
    }

    public SlidesColour slidesColour;
    Dialogue dialogue;

    void Start()
    {
        Item.buttonClickDelegateItem += OnInteract;
        dialogue = new Dialogue();
        string[] new_sentences = new string[1];
        string colour = (slidesColour.Equals(SlidesColour.RED)) ? "red" :(slidesColour.Equals(SlidesColour.BLUE))? "blue":"green";
        new_sentences[0] = "The slides seem to be " + colour + " in colour.";
        dialogue.sentences = new_sentences;
    }


    void Update()
    {
    }

    void OnInteract(string gameObjectName)
    {

        if (gameObjectName == "Glass Slides Red" || gameObjectName == "Glass Slides Blue")
        {

            RaycastHit hitInfo;
            GameObject target = ReturnClickedObject(out hitInfo);
            if (target != null)
            {
                Debug.Log("target position :" + target.name);
                if(target.name == "Microscope_interactable")
                {
                    TriggerDialogue();
                }

            }

        }

    }

    void OnDisable()
    {
        Item.buttonClickDelegateItem -= OnInteract;
    }

    private GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
