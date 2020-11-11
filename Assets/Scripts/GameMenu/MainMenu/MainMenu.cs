using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject instructions;
    private bool isActive = false;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().Play("Click");
        FindObjectOfType<AudioManager>().Stop("Theme");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void HowToPlay()
    {
        if (!isActive)
        {
            instructions.gameObject.SetActive(true);
            isActive = true;
        }
        else
        {
            instructions.gameObject.SetActive(false);
            isActive = false;
        }
    }


}
