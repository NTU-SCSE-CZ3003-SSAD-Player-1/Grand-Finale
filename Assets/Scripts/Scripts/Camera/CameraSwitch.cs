using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject[] cameras;
    AudioListener[] cameraAudioListener;
    int TOTALCAM = 4;

    void Start()
    {
        //initalise variables
        TOTALCAM = cameras.Length;
        cameraAudioListener = new AudioListener[TOTALCAM];

        //Get Camera Listeners
        for (int i = 0; i < TOTALCAM; i++)
        {
            cameraAudioListener[i] = cameras[i].GetComponent<AudioListener>();
        }

        //Camera Position Set
        //store last camera used: PlayerPrefs.GetInt("CameraPosition")
        cameraPositionChange(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //UI JoyStick Method
    //public void cameraPositonM()
    //{
    //    cameraChangeCounter();
    //}

    //Change Camera Keyboard
    void switchCamera()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && control)
        {
            cameraChangeCounter(1);
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && control)
        {
            cameraChangeCounter(-1);
        }
    }

    //Camera Counter
    public void cameraChangeCounter(int movement)
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter += movement;
        cameraPositionChange(cameraPositionCounter);
    }

    //Get Current Camera
    public GameObject getCamera(int camPosition)
    {
        if (camPosition >= TOTALCAM)
        {
            camPosition = 0;
        }
        else if (camPosition < 0)
        {
            camPosition = TOTALCAM - 1;
        }

        return cameras[camPosition];
    }
    private bool control = true;
    //Ignore key presses
    public void iHaveControl()
    {
        control = false;
    }

    //Obeys key presses again
    public void youHaveControl()
    {
        control = true;
    }

    //Camera change Logic
    public void cameraPositionChange(int camPosition)
    {
        if (camPosition >= TOTALCAM)
        {
            camPosition = 0;
        }
        else if (camPosition < 0)
        {
            camPosition = TOTALCAM - 1;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        for (int i = 0; i < TOTALCAM; i++)
        {
            if (camPosition == i)
            {
                cameras[i].SetActive(true);
                cameraAudioListener[i].enabled = true;
            }
            else
            {
                cameras[i].SetActive(false);
                cameraAudioListener[i].enabled = false;

            }
        }

    }
}