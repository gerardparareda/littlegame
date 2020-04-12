using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTexture : Interactable
{
    public Texture[] textures;
    public int currentTexture;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = textures[currentTexture];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            changeTexture();
        }
    }

    //Esquerra
    public override void Hit()
    {
        changeTexture();
    }

    //Dret
    public override void Interact()
    {

    }

    public void changeTexture() {
        if (Object.FindObjectOfType<CleanHability>().canClean() && currentTexture < textures.Length)
        {         
            currentTexture++;
            Object.FindObjectOfType<CleanHability>().clean();
            GetComponent<Renderer>().material.mainTexture = textures[currentTexture];
        }

        if(currentTexture == textures.Length - 1)
        {
            Destroy(gameObject);
        }
    }
}
