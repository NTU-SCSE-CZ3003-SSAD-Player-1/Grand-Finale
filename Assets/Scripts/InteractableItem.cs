using UnityEngine;
using System.Collections;

public class InteractableItem : Interactable
{

    private void Start()
    {
        base.FirstInteract = true;
        if (item.itemtype == ItemType.ITEM)
        {
            PreinsertDialogue();
        }

    }

    public override void OnInteract()
    {
        Pickup();

        if (base.FirstInteract)
        {
            base.OnInteract();
            base.FirstInteract = false;
        }

    }

    private void Pickup()
    {
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {

            FindObjectOfType<AudioManager>().Play("PickupItem");
            //Destroy(this.gameObject);
            FindObjectOfType<GameObjectManager>().SetActive(false, item.gameObjectName, item.isHandHeld);

        }
    }

    public void PreinsertDialogue()
    {
        //hard code into storing new item.
        string[] new_sentences = new string[base.dialogue.sentences.Length + 1];
        new_sentences[0] = "Obtained " + item.name + " and placed into your backpack...";
        for (int i = 1; i < new_sentences.Length; i++)
        {
            new_sentences[i] = base.dialogue.sentences[i - 1];
        }
        base.dialogue.sentences = new_sentences;
    }
}
