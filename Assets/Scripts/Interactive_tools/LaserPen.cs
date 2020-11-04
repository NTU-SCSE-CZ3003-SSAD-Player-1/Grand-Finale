using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserPen : MonoBehaviour
{

    public Camera prismCam;
    public static bool isMainCam;
    public GameObject left, right, down;
    public GameObject cameraScript;
    private CameraSwitch camSwitchInstance;
    private UnityEngine.Events.UnityAction backAction;


    void Start()
    {
        Item.buttonClickDelegateItem += OnInteract;

        isMainCam = true;
        prismCam.gameObject.SetActive(false);
        camSwitchInstance = cameraScript.GetComponent<CameraSwitch>();
        backAction = goBack;
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    if (isMainCam) {
        //        return;
        //    } // No interation for keys
        //    goBack();
        //}
        
    }

    void OnInteract(string gameObjectName)
    {
        if (gameObjectName == "Laser")
        {
            this.gameObject.transform.eulerAngles = new Vector3(-72, 82, -78);
            Debug.Log("use laser");
        }


    }

    void OnDisable()
    {
        Item.buttonClickDelegateItem -= OnInteract;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PenCollider")
        {
            Debug.Log("laser collider activate scene");

            int currentCameraPos = PlayerPrefs.GetInt("CameraPosition");
            camSwitchInstance.getCamera(currentCameraPos).SetActive(false);
            prismCam.gameObject.SetActive(true);
            prismCam.GetComponent<AudioListener>().enabled = true;
            left.SetActive(false);
            right.SetActive(false);
            down.SetActive(true);
            down.GetComponent<Button>().onClick.AddListener(backAction);
            camSwitchInstance.getCamera(currentCameraPos).GetComponent<AudioListener>().enabled = false;
            camSwitchInstance.iHaveControl();
            isMainCam = false;
            
        }
    }

    void goBack()
    {
        // Go back to main cam
        int currentCameraPos = PlayerPrefs.GetInt("CameraPosition");
        prismCam.gameObject.SetActive(false);
        prismCam.GetComponent<AudioListener>().enabled = false;
        camSwitchInstance.cameraPositionChange(currentCameraPos);
        isMainCam = true;
        left.SetActive(true);
        right.SetActive(true);
        down.SetActive(false);
        down.GetComponent<Button>().onClick.RemoveListener(backAction);
        camSwitchInstance.youHaveControl();
    }
}
