using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyline1 : MonoBehaviour
{
    public Dialogue sd, repeatD, endD;
    public GameObject endObject;

    void Start()
    {
        StartCoroutine(callStartDialog());
    }

    private IEnumerator callStartDialog()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Callinng Start");
        int endgame = PlayerPrefs.GetInt("end_game", 0);
        if (endgame <= 0)
        {
            int timesPlayed = PlayerPrefs.GetInt("times_played", 0);
            endObject.SetActive(false);
            if (timesPlayed <= 0)
                FindObjectOfType<DialogueManager>().StartDialogue(sd);
            else
            {
                endObject.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(repeatD);
            }
        } else
        {
            PlayerPrefs.SetInt("end_game", 0);
            PlayerPrefs.SetInt("times_played", 0);
            DialogueManager.OnEndDialogTrigger += EndScene;
            FindObjectOfType<DialogueManager>().StartDialogue(endD);
        }
        
    }

    public void EndScene()
    {
        DialogueManager.OnEndDialogTrigger -= EndScene;
        FindObjectOfType<LevelChanger>().BackToMenu();
    }

    private void Update()
    {


    }

}
