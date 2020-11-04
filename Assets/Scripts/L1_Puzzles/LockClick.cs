using System;
using UnityEngine;
using UnityEngine.UI;

public class LockClick : MonoBehaviour
{

    public Camera lockCam;
    public Camera mainCam;

    public static bool switchBack;


    public LockClick() { }

    private void Start()
    {
        switchBack = false;
        mainCam.gameObject.SetActive(false);
        lockCam.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mainCam.gameObject.activeSelf && !L1CameraController.isMainCam)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100);
            if (hit.collider != null)
            {
                //Debug.Log("Hit: " + hit.point);
                if (hit.collider.CompareTag("padlock"))
                {
                    mainCam.gameObject.SetActive(false);
                    lockCam.gameObject.SetActive(true);
                    mainCam.GetComponent<AudioListener>().enabled = false;
                    lockCam.GetComponent<AudioListener>().enabled = true;
                    switchBack = false;
                }
            }
        }

        if (switchBack)
        {
            Debug.Log("Switing back camera");
            lockCam.gameObject.SetActive(false);
            mainCam.gameObject.SetActive(true);
            mainCam.GetComponent<AudioListener>().enabled = true;
            lockCam.GetComponent<AudioListener>().enabled = false;
            switchBack = false;
        }
    }
}
