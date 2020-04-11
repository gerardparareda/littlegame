using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missio2 : Quest
{

    public string ItemName = "Cube of power";
    public string Explanation = "Agafa 1 cub de poder";
    public int CurrentAmount = 0;
    public int RequiredAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("missio2");
        QuestName = "Missio2";
        Description = "Fes coses";
        //ItemReward = "Destral";

        Goals.Add(new CollectionGoal(this, ItemName, Explanation, false, CurrentAmount, RequiredAmount));
        Goals.ForEach(g => g.Init());
    }
}