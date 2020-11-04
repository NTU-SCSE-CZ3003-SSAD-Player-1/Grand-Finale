using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class ElectricalBoxPuzzle : MonoBehaviour
{
    public static event Action<int> RequestUpdateElectrical = delegate { };

    public GameObject start1, start2, start3, start4, end1, end2, end3, end4;

    public GameObject w11, w12, w13, w14, w21, w22, w23, w24, w31, w32, w33, w34, w41, w42, w43, w44;

    public GameObject sucobj;

    public AudioSource successSound;

    public TextMeshPro wallText;

    public Camera puzcam;

    private int[] sCol = { 0, 1, 2, 3 }, eCol = { 0, 1, 2, 3 };
    private Color[] colorsUsed = { Color.red, Color.blue, Color.green, Color.magenta };

    private int selStart, selEnd, wiresShown;

    public ElectricalBoxPuzzle()
    {
        selStart = -1;
        selEnd = -1;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (!start1 || !start2 || !start3 || !start4)
        {
            Debug.Log("[FATAL] NO START WIRES. CANNOT CONTINUE");
        }

        if (!end1 || !end2 || !end3 || !end4)
        {
            Debug.Log("[FATAL] NO END WIRES. CANNOT CONTINUE");
        }

        if(!w11 || !w12 || !w13 || !w14)
        {
            Debug.Log("[FATAL] NO WIRE 1. CANNOT CONTINUE");
        }

        if(!w21 || !w22 || !w23 || !w24)
        {
            Debug.Log("[FATAL] NO WIRE 2. CANNOT CONTINUE");
        }

        if(!w31 || !w32 || !w33 || !w34)
        {
            Debug.Log("[FATAL] NO WIRE 3. CANNOT CONTINUE");
        }

        if(!w41 || !w42 || !w43 || !w44)
        {
            Debug.Log("[FATAL] NO WIRE 4. CANNOT CONTINUE");
        }

        Shuffle();

        colorObject(start1, colorsUsed[sCol[0]]);
        colorObject(start2, colorsUsed[sCol[1]]);
        colorObject(start3, colorsUsed[sCol[2]]);
        colorObject(start4, colorsUsed[sCol[3]]);
        colorObject(end1, colorsUsed[eCol[0]]);
        colorObject(end2, colorsUsed[eCol[1]]);
        colorObject(end3, colorsUsed[eCol[2]]);
        colorObject(end4, colorsUsed[eCol[3]]);

        toggleWire(1, 1, false);
        toggleWire(1, 2, false);
        toggleWire(1, 3, false);
        toggleWire(1, 4, false);
        toggleWire(2, 1, false);
        toggleWire(2, 2, false);
        toggleWire(2, 3, false);
        toggleWire(2, 4, false);
        toggleWire(3, 1, false);
        toggleWire(3, 2, false);
        toggleWire(3, 3, false);
        toggleWire(3, 4, false);
        toggleWire(4, 1, false);
        toggleWire(4, 2, false);
        toggleWire(4, 3, false);
        toggleWire(4, 4, false);
        wiresShown = 0;

        wallText.enabled = false;
        wallText.gameObject.SetActive(false);

        sucobj.SetActive(false);

        LockControl.CombiUpdate += updateWallCode;
    }

    private void updateWallCode(int l1, int l2, int l3, int l4)
    {
        string show = "_" + l3 + "" + l4;
        wallText.text = show;
    }

    private void colorObject(GameObject obj, Color color)
    {
        var renderer = obj.GetComponent<Renderer>();
        renderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !L1CameraController.isMainCam && puzcam.gameObject.activeSelf)
        {
            Ray ray = puzcam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100);
            if (hit.collider != null)
            {
                Debug.Log("EHit: " + hit.point);
                if (hit.collider.CompareTag("ring"))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    // Handle something there
                    handleClick(hit.collider.gameObject);
                }
            }
        }
    }

    public void Shuffle() {
        int tmp;
        for (int i = 0; i < sCol.Length; i++) {
            int rnd = Random.Range(0, sCol.Length);
            tmp = sCol[rnd];
            sCol[rnd] = sCol[i];
            sCol[i] = tmp;
        }
        for (int i = 0; i < eCol.Length; i++)
        {
            int rnd = Random.Range(0, eCol.Length);
            tmp = eCol[rnd];
            eCol[rnd] = eCol[i];
            eCol[i] = tmp;
        }
    }

    private void handleClick(GameObject obj)
    {
        string name = obj.name;
        string tag = name.Substring(0, 1).ToLower();
        int num = int.Parse(name.Substring(1, 1));
        if (tag == "s") selStart = num;
        else if (tag == "e") selEnd = num;
        if (selStart != -1 && selEnd != -1)
        {
            checkWire();
        }

    }

    private void checkWire()
    {
        // Check if rings same color
        Debug.Log("SELS: " + selStart + " | SELE: " + selEnd);
        if (sCol[selStart-1] == eCol[selEnd-1])
        {
            // Same color, form wire
            Debug.Log("Setting wire w" + (selStart) + (selEnd) + " visible");
            toggleWire(selStart, selEnd, true, colorsUsed[sCol[selStart-1]]);
            wiresShown++;
            checkWin();
        } else
        {
            Debug.Log("WRONG COLOR");
        }

        selStart = -1;
        selEnd = -1;
    }
    IEnumerator TaskSuccess()
    {
        yield return new WaitForSeconds(0f);
        successSound.Play();
    }
    private void checkWin()
    {
        if (wiresShown >= 4)
        {
            StartCoroutine(TaskSuccess());
            RequestUpdateElectrical(1);
            wallText.enabled = true;
            wallText.gameObject.SetActive(true);
            sucobj.SetActive(true);
            sucobj.GetComponent<InteractableObject>().OnInteract();
        }
    }

    private void toggleWire(int start, int end, bool enabled)
    {
        toggleWire(start, end, enabled, Color.white);
    }

    private void toggleWire(int start, int end, bool enabled, Color color)
    {
        string tmp = start + "" + end;
        switch (tmp)
        {
            case "11": w11.SetActive(enabled); colorObject(w11, color); break;
            case "12": w12.SetActive(enabled); colorObject(w12, color); break;
            case "13": w13.SetActive(enabled); colorObject(w13, color); break;
            case "14": w14.SetActive(enabled); colorObject(w14, color); break;
            case "21": w21.SetActive(enabled); colorObject(w21, color); break;
            case "22": w22.SetActive(enabled); colorObject(w22, color); break;
            case "23": w23.SetActive(enabled); colorObject(w23, color); break;
            case "24": w24.SetActive(enabled); colorObject(w24, color); break;
            case "31": w31.SetActive(enabled); colorObject(w31, color); break;
            case "32": w32.SetActive(enabled); colorObject(w32, color); break;
            case "33": w33.SetActive(enabled); colorObject(w33, color); break;
            case "34": w34.SetActive(enabled); colorObject(w34, color); break;
            case "41": w41.SetActive(enabled); colorObject(w41, color); break;
            case "42": w42.SetActive(enabled); colorObject(w42, color); break;
            case "43": w43.SetActive(enabled); colorObject(w43, color); break;
            case "44": w44.SetActive(enabled); colorObject(w44, color); break;
        }
    }

    private void OnDestroy()
    {
        LockControl.CombiUpdate -= updateWallCode;
    }
}
