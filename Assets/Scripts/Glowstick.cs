using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowstick : MonoBehaviour
{
    //[Range(0f, 3f)]
    //public float distance = 1.0f;
    //bool activateItem;
    // public Animator secret_door_animator;
    // public Light lightbulb;

    void Start()
    {
        Item.buttonClickDelegateItem += OnInteract;
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
        //if(gameObjectName == "Glowstick")
        {
            //activateItem = true;
            //if (activateItem)
            //{

            //    this.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            //    this.gameObject.transform.eulerAngles = new Vector3(-72, 82, -78);
            //    GameObject ChildGameObject1 = this.gameObject.transform.GetChild(0).gameObject;
            //    ChildGameObject1.SetActive(true);
            //}
            this.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            this.gameObject.transform.eulerAngles = new Vector3(-45, -280, 70);
            GameObject ChildGameObject1 = this.gameObject.transform.GetChild(0).gameObject;
            ChildGameObject1.SetActive(true);
        }
        //else
        //{
        //    activateItem = false;
        //}
        

    }

    void OnDisable()
    {
        Item.buttonClickDelegateItem -= OnInteract;
    }

}
