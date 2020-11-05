using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSlides : MonoBehaviour
{
    Dialogue dialogue;

    void Start()
    {

        Item.buttonClickDelegateItem += OnInteract;
    }


    void Update()
    {
    }

    void OnInteract(string gameObjectName)
    {

        if (gameObjectName == "Glass Slides 1" || gameObjectName == "Glass Slides 2" || gameObjectName == "Glass Slides 3")
        {


            dialogue = new Dialogue();
            string[] new_sentences = new string[1];

            if (gameObjectName == "Glass Slides 1")
            {
                new_sentences[0] = "The slides seem to be red in colour.";
            }
            else if (gameObjectName == "Glass Slides 2")
            {
                new_sentences[0] = "The slides seem to be green in colour.";
            }
            else
            {
                new_sentences[0] = "The slides seem to be blue in colour.";
            }

            dialogue.sentences = new_sentences;

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
