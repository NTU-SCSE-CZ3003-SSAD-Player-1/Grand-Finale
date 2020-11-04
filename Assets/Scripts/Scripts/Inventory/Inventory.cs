using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    public List<Item> items = new List<Item>();
    public int space = 24;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            //shouldn't happen though. 
            Debug.Log("Not enough room");
            return false;
        }


        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();


        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
