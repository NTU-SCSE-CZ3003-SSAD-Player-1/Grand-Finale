using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;

    void Start()
    {
        
    }

    //void OnMouseDown ()
    //{
    //    breakObject();
    //}

    public void breakObject()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
        FindObjectOfType<AudioManager>().Play("GlassSmash");
        Destroy(gameObject);
    }

}
