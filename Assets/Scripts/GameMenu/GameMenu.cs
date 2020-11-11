using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public GameObject gameCanvas;
    private bool isPause = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
                PauseGame();
            else
                ResumeGame();
        }

    }
    public void ResumeGame()
    {

        Time.timeScale = 1f;
        isPause = false;
        AudioListener.pause = false;
        FindObjectOfType<AudioManager>().Play("Popup");
        gameCanvas.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        //Application.Quit();
        FindObjectOfType<LevelChanger>().BackToMenu();
        //SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("Click");
        ResumeGame();
    }

    public void PauseGame() {

        Time.timeScale = 0f;
        isPause = true;
        AudioListener.pause = true;
        FindObjectOfType<AudioManager>().Play("Popup");
        gameCanvas.gameObject.SetActive(true);
    }



}
