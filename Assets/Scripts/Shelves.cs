// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// using System;
// using UnityEngine;
// using UnityEngine.UI;

// public class Shelves : MonoBehaviour
// {
//     public Camera shelveCam;
//     public Camera mainCamera;

//     public static bool switchBack;


//     public Shelves() { }

//     private void Start()
//     {
//         switchBack = false;
//         shelveCam.enabled = false;
//         mainCamera.enabled = true;
//     }

//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0) && mainCamera.enabled)
//         {
//             Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
//             RaycastHit hit;
//             Physics.Raycast(ray, out hit, 100);
//             if (hit.collider != null)
//             {
//                 Debug.Log("Hit: " + hit.point);
//                 if (hit.collider.CompareTag("Interactable"))
//                 {
//                     Debug.Log("YAY PADLOCK HIT!");
//                     mainCamera.enabled = false;
//                     shelveCam.enabled = true;
//                     switchBack = false;
//                 }
//             }
//         }

//         if (switchBack)
//         {
//             //Debug.Log("Switing back camera");
//             shelveCam.enabled = false;
//             maimainCameranCam.enabled = true;
//             switchBack = false;
//         }
//     }
// }
