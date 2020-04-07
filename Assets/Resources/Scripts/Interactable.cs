using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    Transform player;

    //bool hasInteracted = false;

    public virtual void Interact()
    {
        // Method overwritten for each type of interactable object
        Debug.Log("Interacting with: " + transform.name);
    }


    private void Update()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
<<<<<<< HEAD
                //Debug.Log("INTERACT");
=======
>>>>>>> 296015d7855c5fe91ae34386f511fb6fc532d401
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused ()
    {
        isFocus = false;
        player = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
