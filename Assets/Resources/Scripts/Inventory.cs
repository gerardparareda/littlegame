using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory instance! Error");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public bool clickedOption;
    public Slider waterSlider;

    public int space = 2;

    public List<Item> items = new List<Item>();
    InventorySlot usedSlot;

    GameManager gameManager;
    CleanHability cleanHability;

    void Start()
    {
        gameManager = GameManager.instance;
        cleanHability = gameManager.player.GetComponent<CleanHability>();
    }

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Not enough space in inventory");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Use(InventorySlot inventorySlot)
    {
        gameManager.player.GetComponent<PlayerController>().setUsingItem(inventorySlot.item);
        if (usedSlot != null)
        {
            usedSlot.DeselectSlot();
        }
        usedSlot = inventorySlot;

        if (usedSlot.item.name == "Escombra")
        {
            waterSlider.gameObject.SetActive(true);
            UpdateWaterSlide();
        }
        else
        {
            waterSlider.gameObject.SetActive(false);
        }
    }

    public void UnequipAll()
    {
        waterSlider.gameObject.SetActive(false);
    }

    public void Drop (Item item)
    {
        //Spawn
        Debug.Log("Drop");
        Instantiate(item.prefab, gameManager.player.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Remove(item);
        UnequipAll();
    }

    public Item SearchByName (string name)
    {
        return items.Find(i => i.name == name);
    }

    public void UpdateWaterSlide()
    {
        waterSlider.value = ((cleanHability.maxCleanedObjects - cleanHability.cleanedObjects) / (float)cleanHability.maxCleanedObjects);
    }

}
