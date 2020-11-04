using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LockControl : MonoBehaviour
{
    public GameObject firstCodeBoard;
    public static event Action<int, int, int, int> CombiUpdate = delegate { };

    public LockControl() { }

    private int[] result, correctCombination;
    private bool isOpened;
    private void Start()
    {
        result = new int[]{0,0,0,0};
        correctCombination = new int[] {getRandomNumber(), getRandomNumber(), getRandomNumber(), getRandomNumber() };
        isOpened = false;
        Rotate.Rotated += CheckResults;
        Debug.Log("Sending combi code to chest");
        CombiUpdate(correctCombination[0], correctCombination[1], correctCombination[2], correctCombination[3]);
        UnlockChest.RequestUpdate += reqUpd;
        ElectricalBoxPuzzle.RequestUpdateElectrical += reqUpd;
        updateClipboard();
    }

    private void updateClipboard()
    {
        int num1 = correctCombination[0];
        int num2 = correctCombination[1];
        string value = num1 + "," + num2 + "...";
        firstCodeBoard.GetComponent<InteractableObject>().Dialogue.sentences[1] = "There are some numbers on it \"" + value + "\". The rest must be in the torn off portion of the paper ";
    }

    private void reqUpd(int ignore)
    {
        Debug.Log("[MANUAL] Sending combi code to chest");
        CombiUpdate(correctCombination[0], correctCombination[1], correctCombination[2], correctCombination[3]);
    }

    private int getRandomNumber()
    {
        return UnityEngine.Random.Range(0, 10);
    }

    private void CheckResults(string wheelName, int number)
    {
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
            Debug.Log("Unlocked");
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
            FindObjectOfType<AudioManager>().Play("LockClickOpen");
            isOpened = true;
        }
    }

    private void OnDestroy()
    {
        UnlockChest.RequestUpdate -= reqUpd;
        ElectricalBoxPuzzle.RequestUpdateElectrical -= reqUpd;
        Rotate.Rotated -= CheckResults;
    }
}
