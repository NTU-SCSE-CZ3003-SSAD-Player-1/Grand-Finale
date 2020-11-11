using UnityEngine;
using UnityEngine.UI;

public class L1CameraController : MonoBehaviour
{

    public Camera chestCam, electricalCam, checkLockCam;
    public static bool isMainCam;

    public Image endGameImage;

    public GameObject left, right, down;

    public GameObject cameraScript;
    private CameraSwitch camSwitchInstance;

    private UnityEngine.Events.UnityAction backAction;

    // Start is called before the first frame update
    void Start()
    {
        isMainCam = true;
        chestCam.gameObject.SetActive(false);
        electricalCam.gameObject.SetActive(false);
        camSwitchInstance = cameraScript.GetComponent<CameraSwitch>();
        backAction = goBack;
        endGameImage.color = Color.black;
    }

    void goBack()
    {
        // Go back to main cam
        int currentCameraPos = PlayerPrefs.GetInt("CameraPosition");
        chestCam.gameObject.SetActive(false);
        electricalCam.gameObject.SetActive(false);
        checkLockCam.gameObject.SetActive(false);
        chestCam.GetComponent<AudioListener>().enabled = false;
        electricalCam.GetComponent<AudioListener>().enabled = false;
        checkLockCam.GetComponent<AudioListener>().enabled = false;
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
                if (hit.collider.CompareTag("chestpuzzle"))
                {
                    Debug.Log("Go Chest Puzzle");
                    camSwitchInstance.getCamera(currentCameraPos).SetActive(false);
                    chestCam.gameObject.SetActive(true);
                    chestCam.GetComponent<AudioListener>().enabled = true;
                    left.SetActive(false);
                    right.SetActive(false);
                    down.SetActive(true);
                    down.GetComponent<Button>().onClick.AddListener(backAction);
                    camSwitchInstance.getCamera(currentCameraPos).GetComponent<AudioListener>().enabled = false;
                    camSwitchInstance.iHaveControl();
                    isMainCam = false;
                } else if (hit.collider.CompareTag("electricalpuzzle"))
                {
                    Debug.Log("Go Electrical Puzzle");
                    camSwitchInstance.getCamera(currentCameraPos).SetActive(false);
                    electricalCam.gameObject.SetActive(true);
                    electricalCam.GetComponent<AudioListener>().enabled = true;
                    down.GetComponent<Button>().onClick.AddListener(backAction);
                    camSwitchInstance.getCamera(currentCameraPos).GetComponent<AudioListener>().enabled = false;
                    camSwitchInstance.iHaveControl();
                    left.SetActive(false);
                    right.SetActive(false);
                    down.SetActive(true);
                    isMainCam = false;
                } else if (hit.collider.CompareTag("endgame"))
                {
                    string[] trigger = { "This wasn’t here before...", "Is this…poison…?", "I’d rather die than being stuck here FOREVER!! [drinks the poison]" };
                    // TODO: Show dialogue
                    Dialogue eDialog = new Dialogue();
                    eDialog.sentences = trigger;
                    DialogueManager.OnEndDialogTrigger += EndScene;
                    FindObjectOfType<DialogueManager>().StartDialogue(eDialog);
                    // TODO: Fade to black
                    // TODO: Set flag for EG
                    // TODO: End the game
                }
            }
        }
    }

    public void EndScene()
    {
        DialogueManager.OnEndDialogTrigger -= EndScene;
        PlayerPrefs.SetInt("end_game", 1);
        endGameImage.color = Color.green;
        FindObjectOfType<LevelChanger>().ResetLevel();
    }
}
