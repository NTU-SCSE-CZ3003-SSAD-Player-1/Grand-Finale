using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycardScript : MonoBehaviour
{
    //[Range(0f, 3f)]
    //public float distance = 1.0f;
    //bool activateItem;
    public Animator secret_door_animator;
    public Dialogue placeholderDialog;
    public Item itemObj;
    //public Light lightbulb;
    public bool once;

    void Start()
    {
        Item.buttonClickDelegateItem += OnInteract;
        once = true;
        //activateItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (activateItem)
        //{
        //    Vector3 mousePosition = Input.mousePosition;
        //    mousePosition.z = distance;
        //    transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        //}
    }

    void OnInteract(string gameObjectName)
    {
        Debug.Log("on interact with glowstickkkk !! freakkk!");
            //activateItem = true;
            //if (activateItem)
            //{

            //    this.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            //    this.gameObject.transform.eulerAngles = new Vector3(-72, 82, -78);
            //    GameObject ChildGameObject1 = this.gameObject.transform.GetChild(0).gameObject;
            //    ChildGameObject1.SetActive(true);
            //}
            //this.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            this.gameObject.transform.eulerAngles = new Vector3(-72, 82, -158);
            GameObject ChildGameObject1 = this.gameObject.transform.GetChild(0).gameObject;
            ChildGameObject1.SetActive(true);
        
        //else
        //{
        //    activateItem = false;
        //}
        

    }

    void NextScene()
    {
        DialogueManager.OnEndDialogTrigger -= NextScene;
        FindObjectOfType<LevelChanger>().FadeToLevel();
    }

    void OnDisable()
    {
        Item.buttonClickDelegateItem -= OnInteract;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(placeholderDialog);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "doorCollider")
        {
            Inventory.instance.Remove(itemObj);
            Debug.Log("collision");
                //FindObjectOfType<AudioManager>().Play("DoorOpen");
            secret_door_animator.SetBool("isOpen", true);
            TriggerDialogue();
                DialogueManager.OnEndDialogTrigger += NextScene;
             
            Destroy(this);

            
        }
    }
}