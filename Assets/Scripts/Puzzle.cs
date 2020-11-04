using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public NumberBox boxPrefab;

    public NumberBox[,] boxes = new NumberBox[4,4];

    public Sprite[] sprites;


    // Start is called before the first frame update
    void Start()
    {
        Init();
        for(int i = 0; i < 5; i++)
            Shuffle();
    }

    void Init()
    {
        int n = 0;
        for (int y = 3; y >= 0; y--)
            for (int x = 0; x < 4; x++)
            {
                Vector3 fk = new Vector3(x, y,0);
                NumberBox box = Instantiate(boxPrefab, fk+new Vector3(500,500,500), Quaternion.identity);
                //NumberBox box = Instantiate(boxPrefab,tPoZX , Quaternion.identity);
                box.Init(x, y, n+1, sprites[n], ClickToSwap);
                boxes[x, y] = box;
                n++;
                 //transform.position = new Vector3(Random.Range(-1f, 7f), Random.Range(3.3f, -4f));
                  //tPoZX = new Vector2(Random.Range(-1f, 7f), Random.Range(3.3f, -4f));

                // Instantiate(boxPrefab, boxPrefab.position + (Vector3.up * 1.63f), boxPrefab.rotation * Quaternion.AngleAxis(30.0f, Vector3.up));
                // Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity); 
 
            }
    }

    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x, y);
        int dy = getDy(x, y);
        Swap(x, y, dx, dy);
    }    

    void Swap(int x, int y, int dx, int dy)
    {
        var source = boxes[x, y];
        var target = boxes[x+dx, y+dy];

        /*swap these two boxes*/
        boxes[x,y] = target;
        boxes[x+dx, y+dy] = source;

        /*update pos 2 boxes*/
        source.UpdatePos(x+dx, y+dy);
        target.UpdatePos(x, y);
    }

    int getDx(int x, int y)
    {
       /* is right empty */
       if(x < 3 && boxes[x+1, y].IsEmpty())
            return 1;

        /* is left empty */
       if(x > 0 && boxes[x-1, y].IsEmpty())
            return -1;
        
        return 0;
    }

    int getDy(int x, int y)
    {
        /* is top empty */
       if(y < 3 && boxes[x, y+1].IsEmpty())
            return 1;

        /* is bottom empty */
       if(y > 0 && boxes[x, y-1].IsEmpty())
            return -1;
        
        return 0;
    }

    void Shuffle()
    {
        for(int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(boxes[i, j].IsEmpty())
                {
                    Vector2 pos = getValidMove(i, j);
                    Swap(i, j, (int)pos.x, (int)pos.y);
                }
            }
        }
    }

    private Vector2 lastMove;

    Vector2 getValidMove(int x, int y)
    {
        Vector2 pos = new Vector2();
        do
        {
            int n = Random.Range(0,4);
            if(n == 0)
                pos = Vector2.left;
            else if(n == 1)
                pos = Vector2.right;
            else if(n == 2)
                pos = Vector2.up;
            else
                pos = Vector2.down;
        } while (!(isValidRange(x + (int)pos.x) && isValidRange(y + (int)pos.y)) || isRepeatMove(pos));

        lastMove = pos;
        return pos;
    }

    bool isValidRange(int n)
    {
        return n >= 0 && n <= 3;
    }

    bool isRepeatMove(Vector2 pos)
    {
        return pos * -1 == lastMove;
    }
}
