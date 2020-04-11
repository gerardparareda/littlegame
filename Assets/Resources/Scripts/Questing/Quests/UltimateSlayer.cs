using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSlayer : Quest
{

    public string ItemName = "Cube of power";
    public string Explanation = "Grab a Cube of Power";
    public int CurrentAmount = 0;
    public int RequiredAmount = 2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ultimate slayer assigned");
        QuestName = "UltimateSlayer";
        Description = "Kill a bunch of stuff";
        //ItemReward = "Destral";

        Goals.Add(new CollectionGoal(this, ItemName, Explanation, false, CurrentAmount, RequiredAmount));
        Goals.ForEach(g => g.Init());
    }
}
