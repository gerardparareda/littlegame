using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1.5f;

    //bool hasInteracted = false;

    public virtual void Interact()
    {
        // Method overwritten for each type of interactable object
        Debug.Log("Interacting with: " + transform.name);
    }

    public virtual void Hit()
    {
        //Method overwritten for each type of interactable object
        Debug.Log("Hitting: " + transform.name);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
