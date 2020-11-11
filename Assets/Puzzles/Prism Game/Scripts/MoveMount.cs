using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMount : MonoBehaviour
{
    //private Transform parent;
	
	//public Rigidbody rb;
	public float speed = 1; // speed in meters per second
	private bool control = true; //having control

	// Start is called before the first frame update
	void Start()
    {
		//parent = gameObject.transform.parent;
    }
	

    // Update is called once per frame
    void Update()
    {
        if (control)
        {

			Vector3 moveDir = Vector3.zero;
			//moveDir.x = Input.GetAxis("Horizontal"); // get result of AD keys in X
			moveDir.z = Input.GetAxis("Vertical"); // get result of WS keys in Z (UP DOWN)
												   // move this object at frame rate independent speed:


			Vector3 holder = this.transform.position;
			holder += moveDir * speed * Time.deltaTime;

			//transform.position += moveDir * speed * Time.deltaTime;
			if (holder.z >= 9.6 && holder.z <= 18)
			{
				transform.position += moveDir * speed * Time.deltaTime;
			}

			//Debug.Log(transform.position);
		}
    }

	public bool Control
	{
		set => control = value;
	}
}
