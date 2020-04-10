using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderFocusObject : MonoBehaviour
{
    // Activate outline if mouse is over
    private void OnMouseOver()
    {
        //if (closePlayer)
        gameObject.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0.10f); 
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0.0f);
    }
}
