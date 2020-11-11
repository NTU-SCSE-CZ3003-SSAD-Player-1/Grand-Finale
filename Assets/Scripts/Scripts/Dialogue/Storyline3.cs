using UnityEngine;
using System.Collections;

public class Storyline3 : MonoBehaviour
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
        {
            FindObjectOfType<DialogueManager>().StartDialogue(repeatD);
        }

    }

    private void Update()
    {


    }
}
