using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    public KillGoal(Quest quest, string itemId, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemId;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
        this.GoalType = "KillGoal";
        QuestCounter.instance.numberOfActiveKillGoal++;
        QuestUI.Instance.AddNewQuest(quest.QuestName, Description);
    }



    public override void Init()
    {
        base.Init();
        EnemyStats.onEnemyDeath += EnemyDeath;
        Debug.Log("Hola item pickup");
    }

    void EnemyDeath(string name)
    {

        if (name == this.ItemID)
        {
            Debug.Log("Detected enemy death" + ItemID);
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
