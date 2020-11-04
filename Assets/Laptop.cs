using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laptop : MonoBehaviour
{
    public Canvas canvas;
    public Canvas mainCanvas;
    public Camera craftCam;
    public static bool isMainCam;
    public GameObject down;
    public GameObject cameraScript;
    private CameraSwitch camSwitchInstance;
    private UnityEngine.Events.UnityAction backAction;


    void Start()
    {
        isMainCam = true;
        craftCam.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        camSwitchInstance = cameraScript.GetComponent<CameraSwitch>();
        backAction = goBack;
    }

    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("start craft");
        int currentCameraPos = PlayerPrefs.GetInt("CameraPosition");
        camSwitchInstance.getCamera(currentCameraPos).SetActive(false);
        canvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
        canvas.transform.SetAsLastSibling(); //move to the front (on parent)
        craftCam.gameObject.SetActive(true);
        craftCam.GetComponent<AudioListener>().enabled = true;
        down.SetActive(true);
        down.GetComponent<Button>().onClick.AddListener(backAction);
        camSwitchInstance.getCamera(currentCameraPos).GetComponent<AudioListener>().enabled = false;
        camSwitchInstance.iHaveControl();
        isMainCam = false;
    }

    void goBack()
    {
        // Go back to main cam
        int currentCameraPos = PlayerPrefs.GetInt("CameraPosition");
        craftCam.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
        craftCam.GetComponent<AudioListener>().enabled = false;
        camSwitchInstance.cameraPositionChange(currentCameraPos);
        isMainCam = true;
        down.SetActive(false);
        down.GetComponent<Button>().onClick.RemoveListener(backAction);
        camSwitchInstance.youHaveControl();
    }
}
