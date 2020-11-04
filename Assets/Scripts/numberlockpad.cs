using UnityEngine;
using System.Collections;

public class numberlockpad : MonoBehaviour
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
        currentPW = "687";
        input = "";
        doorOpen = false;
        keypadScreen = false;
        isAnimated = false;
    }

    void Update()
    {
        

        if (doorOpen && !isAnimated)
        {
            animator.SetBool("isOpening", true);
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


                if (GUI.Button(new Rect(x + padding, y + labelHeight + padding, 100, 100), "1", buttonStyle))
                {
                    input += "1";
                }
                else if (GUI.Button(new Rect((x + padding)*2, y + labelHeight + padding, 100, 100), "2", buttonStyle))
                {
                    input += "2";
                }
                else if (GUI.Button(new Rect((x + padding) * 3, y + labelHeight + padding, 100, 100), "3", buttonStyle))
                {
                    input += "3";
                }
                else if (GUI.Button(new Rect(x + padding, y*2 + labelHeight + padding, 100, 100), "4", buttonStyle))
                {
                    input = input + "4";
                }
                else if (GUI.Button(new Rect((x + padding) * 2, y*2 + labelHeight + padding, 100, 100), "5", buttonStyle))
                {
                    input = input + "5";
                }
                else if (GUI.Button(new Rect((x + padding) * 3, y*2 + labelHeight + padding, 100, 100), "6", buttonStyle))
                {
                    input = input + "6";
                }
                else if (GUI.Button(new Rect((x + padding), y*3 + labelHeight + padding, 100, 100), "7", buttonStyle))
                {
                    input = input + "7";
                }
                else if (GUI.Button(new Rect((x + padding) * 2, y*3 + labelHeight + padding, 100, 100), "8", buttonStyle))
                {
                    input = input + "8";
                }
                else if (GUI.Button(new Rect((x + padding) * 3, y*3 + labelHeight + padding, 100, 100), "9", buttonStyle))
                {
                    input = input + "9";
                }
                else if (GUI.Button(new Rect((x + padding) * 2, y*4 + labelHeight + padding, 100, 100), "0", buttonStyle))
                {
                    input = input + "0";
                }
                else if (GUI.Button(new Rect(x + padding, y * 5 + labelHeight + padding, 100, 100), "ENTER", functionButtonStyle))
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
                else if (GUI.Button(new Rect((x + padding)*2, y * 5 + labelHeight + padding, 100, 100), "EXIT", functionButtonStyle))
                {
                    keypadScreen = false;
                }
                else if (GUI.Button(new Rect((x + padding) * 3, y * 5 + labelHeight + padding, 100, 100), "BACKSPACE", functionButtonStyle))
                {
                    input = "";
                }
            }
        }
    }
}
