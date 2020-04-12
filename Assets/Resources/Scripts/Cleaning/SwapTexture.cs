using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTexture : Interactable
{
    public Texture[] textures;
    public int currentTexture;

    private Transform particleFX;
    private ParticleSystem ps;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = textures[currentTexture];
        particleFX = transform.GetChild(0);
        //particleFX.transform.position = transform.position;
        ps = particleFX.GetComponent<ParticleSystem>();
        
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
        
        ps.Stop();
        ps.Clear();
        ps.Play();
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
