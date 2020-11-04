using UnityEngine;


public enum ItemType
{
    ITEM,
    INTERACTABLE
}


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    //#region Singleton
    //public static Item instance;

    //void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Debug.LogWarning("More than one instance of item found!");
    //        return;
    //    }
    //    Debug.Log("item is instansiated");
    //    instance = this;
    //}

    //#endregion

    //has to be on top
    public delegate void DelegateUseButton(string gameobjectName);
    public static event DelegateUseButton buttonClickDelegateItem;

    new public string name = "New Item";
    public Sprite icon = null;
    public string gameObjectName = "gameObject";
    public ItemType itemtype = ItemType.ITEM;
    public bool isHandHeld = false;
    public bool removeFromInventoryWhenUsed = true;


    public virtual void Use()
    {
        Debug.Log("Using " + name);

        FindObjectOfType<GameObjectManager>().SetActive(true, gameObjectName, isHandHeld);
        if (buttonClickDelegateItem != null)
        {
            buttonClickDelegateItem(gameObjectName);
        }
    }



}
