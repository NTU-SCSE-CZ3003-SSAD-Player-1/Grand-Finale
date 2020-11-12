using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class Pieces : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    public bool finished = false;
    public static event Action onFinish = delegate { };
    public bool showOnce; 
    Dialogue dialogue;
    

    // Start is called before the first frame update
    void Start()
    {
      RightPosition = transform.position;
      transform.position = new Vector3(UnityEngine.Random.Range(-17f, -10f), UnityEngine.Random.Range(3.3f, -4f));
        dialogue = new Dialogue();
        string[] new_sentences = new string[2];
        new_sentences[0] = "The power is back!";
        new_sentences[1] = "The lights are turned on!";
        dialogue.sentences = new_sentences;
        showOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
      {
        if (!Selected)
        {
          if (InRightPosition == false)
          {
            transform.position = RightPosition;
            InRightPosition = true;
            GetComponent<SortingGroup>().sortingOrder = 0;
             GetComponent<SortingGroup>().sortingOrder = 0;
            Camera.main.GetComponent<DragDrop>().PlacedPieces++;
            if (Camera.main.GetComponent<DragDrop>().PlacedPieces >= 16)
            {
              Debug.Log("Puzzle Solved");  
              finished = true;
              onFinish();
              TriggerDialogue();

            }
          }
        }
      }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
