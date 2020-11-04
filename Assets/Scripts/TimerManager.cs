﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{

    public static TimerManager instance;
    public Text displayText;
    private bool isActivated;
    private float elapsedTime;
    private TimeSpan timePlaying;
    private bool loopPrevention;
    private float gameTime = 300f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    void Start()
    {
        displayText.text = "Time: 05:00.00";
        isActivated = false;
        loopPrevention = false;
        StartTimer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        isActivated = true;
        elapsedTime = gameTime;

        StartCoroutine("UpdateTimer");

    }

    private IEnumerator UpdateTimer()
    {

        Debug.Log("pls work");
        while (isActivated && elapsedTime>0)
        {
            elapsedTime -= Time.deltaTime;

            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            String timePlayingStr = "Time: " + string.Format("{0:D2}:{1:D2}:{2:D2}", timePlaying.Minutes, timePlaying.Seconds, timePlaying.Milliseconds);
            displayText.text = timePlayingStr;

            if (elapsedTime <= 0)
            {
                //restart level
                displayText.text = "Time: 00:00.00";
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }

            if(timePlaying.Seconds < gameTime-1 && timePlaying.Seconds==0 && loopPrevention == false)
            {
                loopPrevention = true;
                FindObjectOfType<AudioManager>().Play("TimeRush");
            }
            else if (timePlaying.Seconds < gameTime-1 && timePlaying.Seconds != 0 && loopPrevention == true)
            {
                loopPrevention = false;
            }
            

            yield return null;
        }
        //paused

        yield return null;
    }
}