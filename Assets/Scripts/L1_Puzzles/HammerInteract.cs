using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HammerInteract : MonoBehaviour
{

    public CameraSwitch camSwitchInstance;
    public Destructible glasspane;
    public Dialogue breakDialogues;
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
        if (gameObjectStr == "hammer") {
            Debug.Log("Interacting with hammer");
            RaycastHit hitInfo;
            GameObject target = ReturnClickedObject(out hitInfo);
            //GameObject target = ReturnClickedObject(out hitInfo);
            if (target != null)
            {
                Debug.Log("target position :" + target.name);
                if (target.name == "glasspane")
                {
                    glasspane.breakObject();
                    Inventory.instance.Remove(itemObj);
                    TriggerDialogue();
                }

            }
        }
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
        FindObjectOfType<DialogueManager>().StartDialogue(breakDialogues);
    }
}
