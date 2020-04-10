using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTexture : MonoBehaviour
{
    public Texture[] textures;
    public int currentTexture;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            changeTexture();
        }
    }

    void OnMouseOver(){
        
        if(Input.GetMouseButtonDown(0)){
            changeTexture();
        }
    }

    public void changeTexture() {
        currentTexture++;
        currentTexture %= textures.Length;
        GetComponent<Renderer>().material.mainTexture = textures[currentTexture];
    }
}
