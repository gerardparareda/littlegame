using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //public string[] itemTypes;
    public Item[] items;
    public int cleanedObjects;
    public float[] playerPosition;
    public GameObject[] questGuivers;
    public GameObject[] interactableObjects;

    // Class constructor, gets all the necessary data ant puts it in the atributes
    public SaveData()
    {
        //Inventory
        items = Inventory.instance.items.ToArray();
        
        // Player stats
        cleanedObjects = GameManager.instance.player.GetComponent<CleanHability>().cleanedObjects;
        playerPosition = new float[3];

        // Player position
        playerPosition[0] = GameManager.instance.player.transform.position.x;
        playerPosition[1] = GameManager.instance.player.transform.position.y;
        playerPosition[2] = GameManager.instance.player.transform.position.z;

        // Get all questgivers through tag
        questGuivers = GameObject.FindGameObjectsWithTag("QuestGiver");

        // Get all interactable objects
        interactableObjects = GameObject.FindGameObjectsWithTag("Interactable");

    }

    // Used after overriting atributtes in the SaveScript file
    public void LoadToGame()
    {

        // Load inventory data
        Inventory.instance.items.Clear();
        Inventory.instance.items = items.ToList();

        if (Inventory.instance.onItemChangedCallback != null)
            Inventory.instance.onItemChangedCallback.Invoke();
        

        // Load player data
        GameManager.instance.player.GetComponent<CleanHability>().cleanedObjects = cleanedObjects;

        // Player position
        GameManager.instance.player.GetComponent<PlayerController>().controller.enabled = false;
        GameManager.instance.player.transform.position = new Vector3(playerPosition[0], playerPosition[1], playerPosition[2]);
        GameManager.instance.player.GetComponent<PlayerController>().controller.enabled = true;

        // Questgivers
        // First we get all active questgivers to have the reference then we'll delete them
        GameObject[] oldQuestGivers = GameObject.FindGameObjectsWithTag("QuestGiver");
        foreach (GameObject go in questGuivers)
        {
            Object.Instantiate(go);
        }
        foreach (GameObject go in oldQuestGivers)
        {
            Object.Destroy(go);
        }
        GameObject[] oldInteractables = GameObject.FindGameObjectsWithTag("Interactable");
        foreach (GameObject go in oldInteractables)
        {
            Object.Destroy(go);
        }
        foreach (GameObject go in interactableObjects)
        {
            Object.Instantiate(go);
        }

    }
}
