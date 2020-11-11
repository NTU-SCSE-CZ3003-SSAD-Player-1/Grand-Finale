using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]

public class RayCastReflection : MonoBehaviour{

    public int reflection;
    public float maxLength;

    public LineRenderer lineRenderer;
    private Ray laser;
    private RaycastHit hit;
    private Vector3 direction;

    //script to freeze the other movement
    public GameObject moveMount;
    public GameObject laserRotation;
    private LaserRotation laserRotationInstance;
    private MoveMount moveMountInstance;
    private Dialogue dialogue;
    private bool isSuccess = false;

    //prize
    public Item item;



    // Start is called before the first frame update
    void Start()
    {
        laserRotationInstance = laserRotation.GetComponent<LaserRotation>();
        moveMountInstance = moveMount.GetComponent<MoveMount>();
        dialogue = new Dialogue();
        string[] new_sentences = new string[2];
        new_sentences[0] = "You have did it!";
        new_sentences[1] = "Check your inventory for a new item";
        dialogue.sentences = new_sentences;
    }


    private void Update(){

        if (!isSuccess)
        {
            laser = new Ray(transform.position, transform.right);

            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, transform.position);
            float remainingLength = maxLength;

            for (int i = 0; i < reflection; i++)
            {

                if (Physics.Raycast(laser.origin, laser.direction, out hit, remainingLength))
                {
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                    remainingLength -= Vector3.Distance(laser.origin, hit.point);
                    laser = new Ray(hit.point, Vector3.Reflect(laser.direction, hit.normal));
                    if (hit.collider.tag != "Mirror")
                    {
                        if (hit.collider.tag == "Target")
                        {
                            hit.collider.GetComponent<Renderer>().material.color = Color.red;
                            //WIN
                            laserRotationInstance.Control = false;
                            moveMountInstance.Control = false;


                            FindObjectOfType<AudioManager>().Play("Win");
                            Inventory.instance.Add(item);
                            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                            isSuccess = true;
                        }
                        break;
                    }
                }
                else
                {
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, laser.origin + laser.direction * remainingLength);
                }
            }
        }
        
    }
    public void Awake(){
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        laser = new Ray(transform.position, transform.right);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        float remainingLength = maxLength;

        for(int i=0; i< reflection; i++){
            
            if(Physics.Raycast(laser.origin, laser.direction, out hit, remainingLength)){
                if(hit.collider.tag == "Mirror"){
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount -1, hit.point);
                    remainingLength -= Vector3.Distance(laser.origin, hit.point);
                    laser = new Ray(hit.point, Vector3.Reflect(laser.direction, hit.normal));
                }
                else{
                    break;
                }
                
                // lineRenderer.positionCount += 1;
                // lineRenderer.SetPosition(lineRenderer.positionCount -1, hit.point);
                // remainingLength -= Vector3.Distance(laser.origin, hit.point);
                // laser = new Ray(hit.point, Vector3.Reflect(laser.direction, hit.normal));
                // if(hit.collider.tag != "Mirror"){
                //    break;
                // }
                
            }
            else{
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, laser.origin + laser.direction * remainingLength);
            }
        }
    }
    */
}
