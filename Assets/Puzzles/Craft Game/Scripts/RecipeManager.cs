using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class RecipeConverter
{
    private bool blue = false;
    private bool yellow = false;
    private bool red = false;
    private bool orange = false;
    private bool green = false;
    private bool purple = false;
    private bool black = false;
    private bool white = false;
    private ItemSO output;

    public RecipeConverter(RecipeSO recipeSO)
    {
        //blue, yellow, red, orange, green,purple, black, white, glow
        foreach (ItemSO itemSo in recipeSO.topRow)
        {
            if (itemSo == null)
                continue;

            if (itemSo.itemName == "Blue")
            {
                blue = true;
            }
            else if (itemSo.itemName == "Yellow")
            {
                yellow = true;
            }
            else if (itemSo.itemName == "Red")
            {
                red = true;
            }
            else if (itemSo.itemName == "Orange")
            {
                orange = true;
            }
            else if (itemSo.itemName == "Green")
            {
                green = true;
            }
            else if (itemSo.itemName == "Purple")
            {
                purple = true;
            }
            else if (itemSo.itemName == "Black")
            {
                black = true;
            }
            else if (itemSo.itemName == "White")
            {
                white = true;
            }
        }

        output = recipeSO.output;

    }

    public RecipeConverter(ItemSlot[] itemSlots)
    {
        //blue, yellow, red, orange, green,purple, black, white, glow
        foreach (ItemSlot itemSlot in itemSlots)
        {

            if (itemSlot.currItem == null)
                continue;

            if (itemSlot.currItem.itemName == "Blue")
            {
                blue = true;
            }
            else if (itemSlot.currItem.itemName == "Yellow")
            {
                yellow = true;
            }
            else if (itemSlot.currItem.itemName == "Red")
            {
                red = true;
            }
            else if (itemSlot.currItem.itemName == "Orange")
            {
                orange = true;
            }
            else if (itemSlot.currItem.itemName == "Green")
            {
                green = true;
            }
            else if (itemSlot.currItem.itemName == "Purple")
            {
                purple = true;
            }
            else if (itemSlot.currItem.itemName == "Black")
            {
                black = true;
            }
            else if (itemSlot.currItem.itemName == "White")
            {
                white = true;
            }
        }

        output = null;

    }

    public bool[] GetNewRecipe()
    {
        bool[] newReceipe = new bool[8];
        newReceipe[0] = blue;
        newReceipe[1] = yellow;
        newReceipe[2] = red;
        newReceipe[3] = orange;
        newReceipe[4] = green;
        newReceipe[5] = purple;
        newReceipe[6] = black;
        newReceipe[7] = white;

        return newReceipe;
    }

    public bool Compare(bool[] target)
    {
        return Enumerable.SequenceEqual(GetNewRecipe(), target);
    }

    public ItemSO Output
    {
        get => output;
    }
}

public class RecipeManager : MonoBehaviour
{
    public ItemSlot[] topRow = new ItemSlot[3];
    //private List<ItemSlot[]> allSlots = new List<ItemSlot[]>();

    [Space(10)]
    public ItemSlot outputSlot;
    public ItemSlot[] inventorySlots;

    private List<RecipeSO> recipes = new List<RecipeSO>();
    private Dialogue dialogue;

    //prize
    public Item item;
    private bool isSuccess = false;

    //converter class
    List<RecipeConverter> recipeList;


    // Start is called before the first frame update
    void Start()
    {
        //allSlots.Add(topRow);
        //allSlots.Add(midRow);
        //allSlots.Add(bottomRow);

        dialogue = new Dialogue();
        string[] new_sentences = new string[2];
        new_sentences[0] = "Crafting this seems to have unlocked something..";
        new_sentences[1] = "Check your inventory for a new item";
        dialogue.sentences = new_sentences;

        //load recipes
        recipes.AddRange(Resources.LoadAll<RecipeSO>("Recipes/"));
        generatePotionsKey();

    }

    // Update is called once per frame
    void Update()
    {

        if (!isSuccess)
        {
            checkChemicals();
            //foreach (RecipeSO recipe in recipes)
            //{
            //    bool correctPlacement = true;

            //    List<ItemSO[]> allRecipeSlots = new List<ItemSO[]>();
            //    allRecipeSlots.Add(recipe.topRow);
            //    //allRecipeSlots.Add(recipe.midRow);
            //    //allRecipeSlots.Add(recipe.bottomRow);

            //    //Looks at each crafting row
            //    for (int i = 0; i < allRecipeSlots[0].Length; i++)
            //    {
            //        //See if item in row - slot isnt null
            //        if (allRecipeSlots[0][i] != null)
            //        {
            //            //See if item in same crafting table slot isnt null
            //            if (allSlots[0][i].currItem != null)
            //            {
            //                //See if both items arent the same
            //                if (allRecipeSlots[0][i].itemName != allSlots[0][i].currItem.itemName)
            //                {
            //                    correctPlacement = false;
            //                    //continue;
            //                }
            //            }
            //            else
            //            {
            //                correctPlacement = false;
            //                //continue;
            //            }
            //        }
            //        else
            //        {
            //            if (allSlots[0][i].currItem != null)
            //            {
            //                correctPlacement = false;
            //                continue;
            //            }
            //        }
            //    }

            //    if (correctPlacement)
            //    {
            //        outputSlot.currItem = recipe.output;
            //        outputSlot.UpdateSlotData();

            //        if (outputSlot.currItem.itemName == "Glow")
            //        {
            //            isSuccess = true;
            //            Inventory.instance.Add(item);
            //            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            //        }
            //        break;
            //    }
            //    else
            //    {
            //        outputSlot.currItem = null;
            //        outputSlot.UpdateSlotData();
            //    }
            //}
        }
        
    }

    void generatePotionsKey()
    {
        recipeList = new List<RecipeConverter>();
        foreach (RecipeSO recipe in recipes)
        {

            recipeList.Add(new RecipeConverter(recipe));
        }
    }

    void checkChemicals()
    {

        if(topRow[0].currItem != null || topRow[1].currItem != null || topRow[2].currItem != null)
        {

            RecipeConverter itemSlotRecipe = new RecipeConverter(topRow);

            foreach (RecipeConverter recipe in recipeList)
            {
                if (itemSlotRecipe.Compare(recipe.GetNewRecipe()))
                {
                    outputSlot.currItem = recipe.Output;
                    outputSlot.UpdateSlotData();

                    if (outputSlot.currItem.itemName == "Glow")
                    {
                        isSuccess = true;
                        Inventory.instance.Add(item);
                        FindObjectOfType<AudioManager>().Play("Win");
                        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    }
                    //else
                    //    PopItemsBack();

                    break;

                    

                }
                else
                {
                   outputSlot.currItem = null;
                   outputSlot.UpdateSlotData();
                }
                
            }




        }
    }

    void PopItemsBack()
    {

        foreach (ItemSlot itemSlot in topRow)
        {
            if(itemSlot.currItem!= null)
            {
                foreach (ItemSlot itemSlotInInvetory in inventorySlots)
                {
                    if(itemSlotInInvetory.currItem == null)
                    {
                        itemSlotInInvetory.currItem = itemSlot.currItem;
                        itemSlot.currItem = null;
                        itemSlotInInvetory.UpdateSlotData();
                        itemSlot.UpdateSlotData();
                        break;
                    }
                }

            }
        }

        if(outputSlot.currItem != null)
        {
            foreach (ItemSlot itemSlotInInvetory in inventorySlots)
            {
                if (itemSlotInInvetory.currItem == null)
                {
                    itemSlotInInvetory.currItem = outputSlot.currItem;
                    outputSlot.currItem = null;
                    itemSlotInInvetory.UpdateSlotData();
                    outputSlot.UpdateSlotData();
                    break;
                }
            }

        }

        
    }
}
