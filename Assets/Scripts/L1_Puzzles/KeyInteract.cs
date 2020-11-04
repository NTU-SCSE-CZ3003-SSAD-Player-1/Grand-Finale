using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyInteract : MonoBehaviour
{

    public CameraSwitch camSwitchInstance;
    public Dialogue placeholderDialog;
    public Item itemObj;

    // Use this for initialization
    void Start()
    {
        Item.buttonClickDelegateItem += OnInteract;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnInteract(string gameObjectStr)
    {
        if (gameObjectStr == "rust_key")
        {
            Debug.Log("Interacting with key");
            RaycastHit hitInfo;
            GameObject target = ReturnClickedObject(out hitInfo);
            //GameObject target = ReturnClickedObject(out hitInfo);
            if (target != null)
            {
                Debug.Log("target position :" + target.name);
                if (target.name == "Door")
                {
                    Inventory.instance.Remove(itemObj);
                    DialogueManager.onEndDialogTrigger += NextScene;
                    TriggerDialogue();
                }

            }
        }
    }

    void NextScene()
    {
        DialogueManager.onEndDialogTrigger -= NextScene;
        FindObjectOfType<LevelChanger>().FadeToLevel();
    }

    private GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        int currentCameraPos = PlayerPrefs.GetInt("CameraPosition");
        Ray ray = camSwitchInstance.getCamera(currentCameraPos).GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

    void OnDisable()
    {
        Item.buttonClickDelegateItem -= OnInteract;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(placeholderDialog);
    }
}
