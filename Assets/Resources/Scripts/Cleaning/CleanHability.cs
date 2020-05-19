using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanHability : MonoBehaviour
{
    public int maxCleanedObjects;
    public int cleanedObjects;
    public Slider waterSlider;
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clean()
    {
        cleanedObjects++;
        UpdateWaterSlide();

    }

    public void restoreHability()
    {
        cleanedObjects = 0;
    }

    public bool canClean()
    {
        return (cleanedObjects < maxCleanedObjects) && (gameManager.player.GetComponent<PlayerController>().usingItem.name == "Escombra");
    }

    public void UpdateWaterSlide()
    {
        waterSlider.value = ((maxCleanedObjects - cleanedObjects) / (float)maxCleanedObjects);

    }
}
