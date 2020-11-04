using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameObjectManager : MonoBehaviour
{

    GameObject gameObj;
    [Range(0f, 3f)]
    public float distance = 1.0f;
    public static GameObjectManager instance;
    bool activateHandHeld = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    void Update()
    {

        if(gameObj != null && activateHandHeld)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = distance;
            gameObj.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
        
    }
    public void SetActive(bool isActivate, string name, bool isHandheld)
    {
        //GameObject g = Array.Find(gameObjects, game => game.CompareTag(tag));
        //GameObject g = GameObject.Find(path);
        Debug.Log(name);
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Item");

        foreach ( GameObject g in gameObjects)
        {
            if(g.name == name)
            {
                gameObj = g;
                activateHandHeld = isHandheld;

                if (isHandheld)
                {
                    g.GetComponent<MeshRenderer>().enabled = isActivate;
                    g.GetComponent<BoxCollider>().enabled = isActivate;

                    for (int i = 0; i < g.transform.childCount; i++)
                    {
                        var child = g.transform.GetChild(i).gameObject;
                        if (child != null)
                            child.SetActive(isActivate);
                    }
                }
                else
                {
                    //do something to non-heldable items
                    g.GetComponent<MeshRenderer>().enabled = false;
                    g.GetComponent<BoxCollider>().enabled = false;

                    for (int i = 0; i < g.transform.childCount; i++)
                    {
                        var child = g.transform.GetChild(i).gameObject;
                        if (child != null)
                            child.SetActive(false);
                    }
                }

            }
            

        }

        //if (g == null)
        //{
        //    Debug.LogWarning("Game object:"+path+" Not found!");
        //    return;
        //}

        //gameObject.SetActive(isActivate);
        
    }
}
