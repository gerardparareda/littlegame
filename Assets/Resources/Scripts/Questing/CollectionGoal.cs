using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{
    

    public CollectionGoal(Quest quest, string itemId, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemId;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
        this.GoalType = "CollectionGoal";
        QuestCounter.instance.numberOfActiveCollectionGoal++;
        QuestUI.Instance.AddNewQuest(quest.QuestName, Description);
    }
    

    
    public override void Init()
    {
        base.Init();
        ItemPickup.onItemPickUp += ItemPickedUp;
        Debug.Log("Hola item pickup");
    }

    void  ItemPickedUp (Item item)
    {
      
        if (item.name == this.ItemID)
        {
            Debug.Log("Detected item pick up" + ItemID);
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
