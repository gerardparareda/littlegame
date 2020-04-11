using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceRewarded { get; set; }
    //public Item ItemReward { get; set; }
    public bool Completed { get; set; }

    public void CheckGoals()
    {
        //landa operation. 
        Completed = Goals.All(g => g.Completed);
        
    }

    public void GiveReward()
    {
        /*if (ItemReward != null)
        {
            //InventoryController.Instance.GiveItem(ItemReward);
        }*/
        QuestCounter.numberOfActiveQuest--;
        Debug.Log("L'enhorabona!");

    }

    public void DeliverObjects ()
    {
        
        foreach (Goal g in Goals)
        {
            Item item = (Inventory.instance.SearchByName(g.ItemID));
            Debug.Log("hem d eliminar el seguent item" + item.name);

            int a = g.CurrentAmount;

            for (int i = 0; i < a; i++)
            {
                Inventory.instance.Remove(item);
            }
            
        }
        
    }
}
