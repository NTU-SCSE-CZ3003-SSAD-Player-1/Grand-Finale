using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRotation : MonoBehaviour
{
	private Transform parent;
	private GameObject target;
	private bool control = true;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent;
		target = gameObject;
    }

	Vector3 GetMouseWorldPos(){
		Vector3 mousePoint = Input.mousePosition;
		mousePoint.z = 0;
		
		return Camera.main.ScreenToWorldPoint(mousePoint);
	}
	
	private void OnMouseDrag(){
		if(Time.timeScale != 0){
			Vector3 worldMPos = GetMouseWorldPos();
			float newAngle = Mathf.Atan((worldMPos.y - parent.position.y)/worldMPos.x) * Mathf.Rad2Deg;
			if(worldMPos.x > 0){
				//transform.RotateAround(target.transform.position, worldMPos, newAngle);
				gameObject.transform.rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
			}
		}
	}
    // Update is called once per frame
    void Update()
    {
        if (control)
        {
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				//transform.Rotate(Vector3.up, -Time.deltaTime * 100f);
				transform.RotateAround(target.transform.position, Vector3.up, -Time.deltaTime * 10f);
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				//transform.Rotate(Vector3.up, Time.deltaTime * 100f);
				transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * 10f);
			}
		}
    }

	public bool Control
	{
		set => control = value;
	}
}
