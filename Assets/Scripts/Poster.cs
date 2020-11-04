using System;
using UnityEngine;
using UnityEngine.UI;

public class Poster : MonoBehaviour
{

    public Camera lockCam;
    public Camera mainCam;

    public static bool switchBack;


    public Poster() { }

    private void Start()
    {
        switchBack = false;
        lockCam.enabled = false;
        mainCam.enabled = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mainCam.enabled)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100);
            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.point);
                if (hit.collider.CompareTag("poster"))
                {
                    Debug.Log("YAY poster HIT!");
                    mainCam.enabled = false;
                    lockCam.enabled = true;
                    switchBack = false;
                }
            }
        }

        if (switchBack)
        {
            Debug.Log("Switing back camera");
            lockCam.enabled = false;
            mainCam.enabled = true;
            switchBack = false;
        }
    }
}
