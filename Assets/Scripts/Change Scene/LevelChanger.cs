﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public string levelToLoad;
    private bool resetLevel = false;
    private bool mainMenu = false;


    // Update is called once per frame
    void Update()
    {
       
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void ResetLevel()
    {
        resetLevel = true;
        animator.SetTrigger("FadeOut");
    }

    public void BackToMenu()
    {
        mainMenu = true;
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplete()
    {
        if (resetLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            resetLevel = false;
        } else if (mainMenu) {
            mainMenu = false;
            SceneManager.LoadScene("menu_scene");
        } else {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
