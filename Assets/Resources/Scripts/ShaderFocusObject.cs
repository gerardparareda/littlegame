using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderFocusObject : MonoBehaviour
{


    public GameObject player;
    bool closePlayer;

    void Start()
    {
        closePlayer = false;
    }

    void Update()
    {
        //print("Distance from player: " + Vector3.Distance(player.transform.position, gameObject.transform.position));
        changeProperties();

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 1.0f)
        {
            //gameObject.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0.0f);
            closePlayer = true;
        } else
        {
            closePlayer = false;
        }
    }


    void changeProperties()
    {
        if (closePlayer)
        {
            gameObject.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0.15f);
        } else
        {
            gameObject.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0.0f);
        }
    }
}
