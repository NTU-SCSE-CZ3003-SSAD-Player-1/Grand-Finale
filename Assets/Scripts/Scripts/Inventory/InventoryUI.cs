﻿using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;
    InventorySlot[] slots;


    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        //inventory to false first
        ToggleUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            //activate inventory.
            ToggleUI();
        }
    }

    void UpdateUI()
    {
        for (int i=0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void ToggleUI() {

        FindObjectOfType<AudioManager>().Play("Popup");
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
