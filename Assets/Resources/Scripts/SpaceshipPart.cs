using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPart : Interactable
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

        
    }
}
