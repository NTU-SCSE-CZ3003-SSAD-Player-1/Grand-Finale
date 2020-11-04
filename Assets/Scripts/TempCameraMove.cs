using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempCameraMove : MonoBehaviour
{

    public Camera jigsawCam, rearrangeCam;
    public static bool isMainCam;

    public GameObject left, right, down;

    public GameObject cameraScript;
    private CameraSwitch camSwitchInstance;

    private UnityEngine.Events.UnityAction backAction;

    // Start is called before the first frame update
    void Start()
    {
        isMainCam = true;
        jigsawCam.gameObject.SetActive(false);
        rearrangeCam.gameObject.SetActive(false);
        camSwitchInstance = cameraScript.GetComponent<CameraSwitch>();
        backAction = goBack;
    }

    void goBack()
    {
        // Go back to main cam
        int currentCameraPos = PlayerPrefs.GetInt("CameraPosition");
        jigsawCam.gameObject.SetActive(false);
        rearrangeCam.gameObject.SetActive(false);
        jigsawCam.GetComponent<AudioListener>().enabled = false;
        camSwitchInstance.cameraPositionChange(currentCameraPos);
        isMainCam = true;
        left.SetActive(true);
        right.SetActive(true);
        down.SetActive(false);
        down.GetComponent<Button>().onClick.RemoveListener(backAction);
        camSwitchInstance.youHaveControl();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (isMainCam) { return; } // No interation for keys
            goBack();
        }
        int currentCameraPos = PlayerPrefs.GetInt("CameraPosition");
        if (Input.GetMouseButtonDown(0) && isMainCam)
        {
            Ray ray = camSwitchInstance.getCamera(currentCameraPos).GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100);
            if (hit.collider != null)
            {
                //Debug.Log("Hit: " + hit.point);
                if (hit.collider.CompareTag("jigpuzzle"))
                {
                    Debug.Log("Go Chest Puzzle");
                    camSwitchInstance.getCamera(currentCameraPos).SetActive(false);
                    jigsawCam.gameObject.SetActive(true);
                    jigsawCam.GetComponent<AudioListener>().enabled = true;
                    left.SetActive(false);
                    right.SetActive(false);
                    down.SetActive(true);
                    down.GetComponent<Button>().onClick.AddListener(backAction);
                    camSwitchInstance.getCamera(currentCameraPos).GetComponent<AudioListener>().enabled = false;
                    camSwitchInstance.iHaveControl();
                    isMainCam = false;
                } else if (hit.collider.CompareTag("rearrange"))
                {
                    Debug.Log("Go rearrange Puzzle");
                    camSwitchInstance.getCamera(currentCameraPos).SetActive(false);
                    rearrangeCam.gameObject.SetActive(true);
                    rearrangeCam.GetComponent<AudioListener>().enabled = true;
                    down.GetComponent<Button>().onClick.AddListener(backAction);
                    camSwitchInstance.getCamera(currentCameraPos).GetComponent<AudioListener>().enabled = false;
                    camSwitchInstance.iHaveControl();
                    left.SetActive(false);
                    right.SetActive(false);
                    down.SetActive(true);
                    isMainCam = false;
                }
            }
        }
    }
}
