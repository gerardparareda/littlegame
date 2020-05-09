using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    Inventory inventory;
    public Image icon;
    public GameObject utilitiesPanel;
    Item item;

    public void Start()
    {
        inventory = Inventory.instance;
    }

    public void ChangeUtilitiesActive()
    {
        if (!utilitiesPanel.activeSelf)
        {
            utilitiesPanel.GetComponent<Desectable>().GetFocus();
        }
    }

    public void DropItem()
    {
        utilitiesPanel.GetComponent<Desectable>().TakeFocus();
        inventory.Drop(item);
    }

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }


    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

}
