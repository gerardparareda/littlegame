using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler onItemPickUp;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    public override void Hit()
    {
        base.Hit();
        //Coses
    }

    void PickUp()
    {
        
        Debug.Log("Picking up " + item.name);
  
        bool itemPickedUp = Inventory.instance.Add(item);
        if (itemPickedUp) 
        { 
            //Mirem si hi ha un quest actiu. En casa afirmatiu, analitzem el pick up per veure si forma part de la missió.
            if (QuestCounter.numberOfActiveQuest != 0)
            {
                onItemPickUp(item);
            }
            Destroy(gameObject);
        }
    }

}
