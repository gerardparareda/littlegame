using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;

    InventorySlot[] slots;

    void Start()
    {
        // Get the Inventory singleton
        inventory = Inventory.instance;
        // Subscribe to itemchanged callback to call UpdateUI every time Inventory is changed.
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
