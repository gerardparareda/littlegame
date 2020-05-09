using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int space = 2;

    public List<Item> items = new List<Item>();

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
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

    public void Drop (Item item)
    {
        //Spawn
        Debug.Log("Drop");
        Instantiate(item.prefab, gameManager.player.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Remove(item);
    }

    public Item SearchByName (string name)
    {
        return items.Find(i => i.name == name);
    }

}
