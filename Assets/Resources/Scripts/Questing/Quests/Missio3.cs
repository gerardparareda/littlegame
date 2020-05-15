using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missio3 : Quest
{

    public string ItemName = "Tetra brick";
    public string Explanation = "Pick up 5 bricks";
    public int CurrentAmount = 0;
    public int RequiredAmount = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("missio3");
        QuestName = "Bricks";
        Description = "Pick up 5 bricks";
        //ItemReward = "Destral";

        Goals.Add(new CollectionGoal(this, ItemName, Explanation, false, CurrentAmount, RequiredAmount));
        Goals.ForEach(g => g.Init());
    }
}