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
    private Dialogue dialogue;
    private bool isSuccess = false;


    void Start()
    {
        Item.buttonClickDelegateItem += OnInteract;

        isMainCam = true;
        prismCam.gameObject.SetActive(false);
        camSwitchInstance = cameraScript.GetComponent<CameraSwitch>();
        backAction = goBack;


        dialogue = new Dialogue();
        string[] new_sentences = new string[3];
        new_sentences[0] = "Use your ARROW KEYS to control the laser";
        new_sentences[1] = "Up, down to move and left, right to rotate";
        new_sentences[2] = "Your laser has to hit the target to clear this";
        dialogue.sentences = new_sentences;
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
            this.gameObject.transform.eulerAngles = new Vector3(-72, -90, -78);
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

            if (!isSuccess)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                FindObjectOfType<AudioManager>().Play("Laser");
                isSuccess = true;
            }

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
