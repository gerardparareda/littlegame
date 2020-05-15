using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    Inventory inventory;
    public Image icon;
    public GameObject utilitiesPanel;
    public GameObject itemButton;
    public Item item;

    public void Start()
    {
        inventory = Inventory.instance;
    }

    public void ChangeUtilitiesActive()
    {
        if (!utilitiesPanel.activeSelf && icon.enabled)
        {
            utilitiesPanel.GetComponent<Desectable>().GetFocus();
        }
        else
        {
            utilitiesPanel.GetComponent<Desectable>().TakeFocus();
        }
    }

    public void UseItem()
    {
        if (item.equipable)
        {
            inventory.Use(this);
            SelectSlot();
            utilitiesPanel.GetComponent<Desectable>().TakeFocus();
        }
    }

    void SelectSlot()
    {
        itemButton.GetComponent<Image>().color = new Color(1, 0.925f, 0.47f, 1);
    }

    public void DeselectSlot()
    {
        itemButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.439f);
    }

    public void DropItem()
    {
        utilitiesPanel.GetComponent<Desectable>().TakeFocus();
        DeselectSlot();
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
