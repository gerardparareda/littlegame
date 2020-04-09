using UnityEngine;

public class ItemDestroy : Interactable
{

    //public Item item;
    public int life;

    public override void Interact()
    {
        base.Interact();
        // Override with the expected behaviour of interacting a destructible object
    }

    public override void Hit()
    {
        base.Hit();
        Debug.Log("Hitting " + transform.name);

        if (life > 1)
        {
            life--;
        } else if (life == 1)
        {
            life--;
            Destroy(gameObject);
        }
    }
}
