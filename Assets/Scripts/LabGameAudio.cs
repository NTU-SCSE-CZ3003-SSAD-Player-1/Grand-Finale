﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabGameAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        FindObjectOfType<AudioManager>().Play("themelvl3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}