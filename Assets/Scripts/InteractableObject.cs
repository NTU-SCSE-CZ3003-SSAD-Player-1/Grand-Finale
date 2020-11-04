using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InteractableObject : Interactable, IDropHandler
{
    //public Dialogue successfulDialog;


    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            Debug.Log("on drop item");

        }
    }

    public override void OnInteract()
    {

        base.OnInteract();

    }

    //public void PreinsertDialogue()
    //{
    //    //hard code into storing new item.
    //    string[] new_sentences = new string[base.dialogue.sentences.Length + 1];
    //    new_sentences[0] = "Obtained " + item.name + "and placed into your backpack...";
    //    for (int i = 1; i < new_sentences.Length; i++)
    //    {
    //        new_sentences[i] = base.dialogue.sentences[i - 1];
    //    }
    //    base.dialogue.sentences = new_sentences;
    //}


}