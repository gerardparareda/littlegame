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
                //Debug.Log("INTERACT");
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
