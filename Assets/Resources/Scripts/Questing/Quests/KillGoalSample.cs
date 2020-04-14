using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoalSample : Quest
{

    public string ItemName = "Enemy";
    public string Explanation = "Mata un enemic";
    public int CurrentAmount = 0;
    public int RequiredAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("missio2");
        QuestName = "Missio2";
        Description = "Mata un enemic";
        
        //ItemReward = "Destral";

        Goals.Add(new KillGoal(this, ItemName, Explanation, false, CurrentAmount, RequiredAmount));
        Goals.ForEach(g => g.Init());
    }
}