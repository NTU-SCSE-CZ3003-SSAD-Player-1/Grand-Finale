using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    // Start is called before the first frame update
	
	public LineRenderer laser;// = new LineRenderer();
	List<Vector3> laserIndices = new List<Vector3>();
	public LayerMask mask;
	
	int rayCount = 0;
    void Start()
    {
    	//laser = new LineRenderer();
    }

    // Update is called once per frame
    void Update()
    {
        laserIndices.Clear();
		CastRay(gameObject.transform.position, gameObject.transform.right, rayCount);
    }
	
	void CastRay(Vector3 pos, Vector3 dir, int counter){
	laserIndices.Add(pos);
 
		Ray ray = new Ray(pos,dir);
		RaycastHit hit;
 
		if(Physics.Raycast(ray, out hit, 10, 8) & counter < 50){
 
			if(hit.collider.gameObject.tag == "Mirror"){
				pos = hit.point;
				dir = Vector3.Reflect(dir, hit.normal);
 
				counter++;
				CastRay(pos,dir, counter);
			}
			else if(hit.collider.gameObject.tag == "Target"){
				//
				Time.timeScale = 0;
				pos = hit.point;
 
				laserIndices.Add(pos);
 
				int count = 0;
				laser.positionCount = laserIndices.Count;
 
				foreach(Vector3 idx in laserIndices){
					laser.SetPosition(count, idx);
					count++;
				}
			}
			else{
				pos = hit.point;
 
				laserIndices.Add(pos);
 
				int count = 0;
				laser.positionCount = laserIndices.Count;
 
				foreach(Vector3 idx in laserIndices){
					laser.SetPosition(count, idx);
					count++;
				}
			}	
		}
	}
}
