using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UnlockChest : MonoBehaviour
{

    public GameObject door, key;
    public static event Action<int> RequestUpdate = delegate { };

    private int[] result, correctCombination;
    private bool isOpened;
    private bool isConfigured;
    private void Start()
    {
        result = new int[]{0,0,0,0};
        correctCombination = new int[] { 0, 0, 0, 0 };
        isOpened = false;
        isConfigured = false;
        //key.SetActive(false);
        Rotate.Rotated += CheckResultsChest;
        LockControl.CombiUpdate += updateCombination;
    }

    private void updateCombination(int l1, int l2, int l3, int l4)
    {
        isOpened = false;
        correctCombination = new int[] { l1, l2, l3, l4 };
        isConfigured = true;
        Debug.Log("Unlock Code: " + correctCombination[0] + ":" + correctCombination[1] + ":" + correctCombination[2] + ":" + correctCombination[3]);
    }

    private void CheckResultsChest(string wheelName, int number)
    {
        if (!isConfigured)
        {
            RequestUpdate(1);
        }
        switch (wheelName)
        {
            case "WheelOne":
                result[0] = number;
                break;

            case "WheelTwo":
                result[1] = number;
                break;

            case "WheelThree":
                result[2] = number;
                break;

            case "WheelFour":
                result[3] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
            && result[2] == correctCombination[2] && result[3] == correctCombination[3] && !isOpened)
        {
            // Unlock Padlock
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 0.5f);
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y - 90f, transform.rotation.z, transform.rotation.w);

            // Open chest door
            door.transform.localRotation = new Quaternion(door.transform.localRotation.x, door.transform.localRotation.y + 1f, door.transform.localRotation.z, door.transform.localRotation.w);
            isOpened = true;

            key.SetActive(true);
            StartCoroutine(SwitchBackAfter());
        }
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResultsChest;
        LockControl.CombiUpdate -= updateCombination;
    }

    private IEnumerator SwitchBackAfter()
    {
        Debug.Log("Waiting 2 seconds before switching back camera");
        yield return new WaitForSeconds(2f);
        LockClick.switchBack = true;

    }
}
