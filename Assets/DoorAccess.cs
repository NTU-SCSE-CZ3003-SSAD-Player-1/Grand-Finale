// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class DoorAccess : MonoBehaviour
// // {
// //     // Start is called before the first frame update
// //     void Start()
// //     {
        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
        
// //     }
// // }

// using System;
// using UnityEngine;
// using UnityEngine.UI;

// public class DoorAccess : MonoBehaviour
// {

//     public Camera lockCam;
//     public Camera mainCam;

//     public static bool switchBack;


//     public DoorAccess() { }

//     void Start()
//     {
//         switchBack = false;
//         lockCam.enabled = false;
//         mainCam.enabled = true;
//     }

//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0) && mainCam.enabled)
//         {
//             Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
//             RaycastHit hit;
//             Physics.Raycast(ray, out hit, 100);
//             if (hit.collider != null)
//             {
//                 Debug.Log("Hit: " + hit.point);
//                 if (hit.collider.CompareTag("doorcard"))
//                 {
//                     Debug.Log("YAY doorcard HIT!");
//                     mainCam.enabled = false;
//                     lockCam.enabled = true;
//                     switchBack = false;
//                 }
//             }
//         }

//         // if (switchBack)
//         // {
//         //     Debug.Log("Switing back camera");
//         //     lockCam.enabled = false;
//         //     mainCam.enabled = true;
//         //     switchBack = false;
//         // }
//     }
// }
