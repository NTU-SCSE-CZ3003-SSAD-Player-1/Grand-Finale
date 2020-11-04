using UnityEngine;
using System.Collections;

public class doorKeypad : MonoBehaviour
{

    string currentPW;
    string input;
    bool keypadScreen;
    bool doorOpen;
    bool isAnimated;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        currentPW = "GTP";
        input = "";
        doorOpen = false;
        keypadScreen = false;
        isAnimated = false;
    }

    void Update()
    {
        

        if (doorOpen && !isAnimated)
        {
            animator.SetBool("isOpen", true);
            isAnimated = true;
            Debug.Log("DOOR OPENED");
        }
    }

    private void OnMouseDown()
    {
        keypadScreen = true;
    }

    void OnGUI()
    {
        if (!doorOpen)
        {

            if (keypadScreen)
            {
                int x = 100;
                int y = 100;
                int labelHeight = 50;
                int padding = 5;

                GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
                buttonStyle.fontSize = 30;

                GUIStyle functionButtonStyle = new GUIStyle(GUI.skin.button);
                functionButtonStyle.fontSize = 15;

                GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
                boxStyle.fontSize = 40;


                GUI.Box(new Rect(x, y, 320, 355), "");
                GUI.Box(new Rect(x+padding, 100+padding, 310, labelHeight), input, boxStyle);


                if (GUI.Button(new Rect(x + padding, y + labelHeight + padding, 100, 100), "R", buttonStyle))
                {
                    input += "R";
                }
                else if (GUI.Button(new Rect((x + padding)*2, y + labelHeight + padding, 100, 100), "G", buttonStyle))
                {
                    input += "G";
                }
                else if (GUI.Button(new Rect((x + padding) * 3, y + labelHeight + padding, 100, 100), "B", buttonStyle))
                {
                    input += "B";
                }
                else if (GUI.Button(new Rect(x + padding, y*2 + labelHeight + padding, 100, 100), "P", buttonStyle))
                {
                    input = input + "P";
                }
                else if (GUI.Button(new Rect((x + padding) * 2, y*2 + labelHeight + padding, 100, 100), "T", buttonStyle))
                {
                    input = input + "T";
                }
                else if (GUI.Button(new Rect((x + padding) * 3, y*2 + labelHeight + padding, 100, 100), "O", buttonStyle))
                {
                    input = input + "O";
                }
                else if (GUI.Button(new Rect(x + padding, y * 3 + labelHeight + padding, 100, 100), "ENTER", functionButtonStyle))
                {
                    if (input == currentPW)
                    {
                        doorOpen = true;
                    }
                    else
                    {
                        input = "";
                    }
                }
                else if (GUI.Button(new Rect((x + padding)*2, y * 3 + labelHeight + padding, 100, 100), "EXIT", functionButtonStyle))
                {
                    keypadScreen = false;
                }
                else if (GUI.Button(new Rect((x + padding) * 3, y * 3 + labelHeight + padding, 100, 100), "BACKSPACE", functionButtonStyle))
                {
                    input = "";
                }
            }
        }
    }
}
