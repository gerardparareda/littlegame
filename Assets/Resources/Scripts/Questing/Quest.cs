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
        Debug.Log("He entrat a checkGoals");
        //Cal modificar això si posem multiples Goals a un quest.
        foreach (Goal g in Goals)
        {
            if (g.GoalType == "CollectionGoal")
            {
                int a = Inventory.instance.CountByName(g.ItemID); 
                
                if (a >= g.RequiredAmount){
                    Completed = true;
                }
            } else
            {
                if (g.Completed == true)
                {
                    Completed = true;
                }
            }
            
        }

        
        //Completed = Goals.All(g => g.Completed);
        
    }

    public void GiveReward()
    {
        /*if (ItemReward != null)
        {
            //InventoryController.Instance.GiveItem(ItemReward);
        }*/
        QuestCounter.instance.numberOfActiveQuest--;
        Debug.Log("L'enhorabona!");

    }


    //Elimina els objectes entregats de l'inventari del jugador. 
    public void DeliverObjects ()
    {

        QuestUI.Instance.RemoveQuest(QuestName);
        
        foreach (Goal g in Goals)
        {
            if (g.GoalType == "CollectionGoal")
            {
                Item item = (Inventory.instance.SearchByName(g.ItemID));
                Debug.Log("hem d eliminar el seguent item" + item.name);

                int a = g.RequiredAmount;

                for (int i = 0; i < a; i++)
                {
                    Inventory.instance.Remove(item);
                }
            }
        }
        
    }
}
