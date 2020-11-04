using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyline1 : MonoBehaviour
{
    public Dialogue sd;

    void Start()
    {
        StartCoroutine(callStartDialog());
    }

    private IEnumerator callStartDialog()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Callinng Start");
        FindObjectOfType<DialogueManager>().StartDialogue(sd);
    }

    private void Update()
    {


    }

}
