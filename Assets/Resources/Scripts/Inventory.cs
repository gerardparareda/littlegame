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

    public List<Item> items = new List<Item>();


    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove (Item item)
    {
        items.Remove(item);
    }

}
