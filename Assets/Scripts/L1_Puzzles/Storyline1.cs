using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyline1 : MonoBehaviour
{
    public Dialogue sd, repeatD;

    void Start()
    {
        StartCoroutine(callStartDialog());
    }

    private IEnumerator callStartDialog()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Callinng Start");
        int timesPlayed = PlayerPrefs.GetInt("times_played", 0);
        if (timesPlayed <= 0)
            FindObjectOfType<DialogueManager>().StartDialogue(sd);
        else
            FindObjectOfType<DialogueManager>().StartDialogue(repeatD);
    }

    private void Update()
    {


    }

}
