using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragDrop : MonoBehaviour
{
    public GameObject SelectedPiece;
    int order = 1;
     public int PlacedPieces = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
          RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
          if (hit.transform.CompareTag("Puzzle"))
          {
              if (!hit.transform.GetComponent<Pieces>().InRightPosition)
              {
                SelectedPiece = hit.transform.gameObject;
                SelectedPiece.GetComponent<Pieces>().Selected = true;
                SelectedPiece.GetComponent<SortingGroup>().sortingOrder = order;
                order++;
              }
          }
      }

      if (Input.GetMouseButtonUp(0))
      {
        if (SelectedPiece != null)
        {
          SelectedPiece.GetComponent<Pieces>().Selected = false;
          SelectedPiece = null;
        }
      }

      if (SelectedPiece != null)
      {
          Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          SelectedPiece.transform.position = new Vector3(MousePoint.x,MousePoint.y,0);
      }
    }
}
