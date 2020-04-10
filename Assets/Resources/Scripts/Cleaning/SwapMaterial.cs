﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{
    public Material[] materials;
    public Material[] outlineMaterials;
    public int currentMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = materials[currentMaterial];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            changeMaterial();
        }
    }

    void OnMouseOver(){
        GetComponent<Renderer>().material = outlineMaterials[currentMaterial];
        if(Input.GetMouseButtonDown(0)){
            changeMaterial();
        }
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = materials[currentMaterial];
    }

    public void changeMaterial() {
        currentMaterial++;
        currentMaterial %= materials.Length;
        GetComponent<Renderer>().material = materials[currentMaterial];
    }
}
