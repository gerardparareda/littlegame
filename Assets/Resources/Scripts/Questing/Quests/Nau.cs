using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nau : Quest
{
    // Start is called before the first frame update
    public string ItemName = "Space Ship Part";
    public string Explanation = "Spaceship cannot launch if it isn't complete";
    public int CurrentAmount = 0;
    public int RequiredAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ultimate slayer assigned");
        QuestName = "NAU 101";
        Description = "Spaceship cannot launch if it isn't complete";

        //ItemReward = "Destral";

        Goals.Add(new CollectionGoal(this, ItemName, Explanation, false, CurrentAmount, RequiredAmount));
        Goals.ForEach(g => g.Init());
    }
}
