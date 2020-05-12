using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nau : Quest
{
    // Start is called before the first frame update
    public string ItemName = "Tetra brick";
    public string Explanation = "La nau no pot engegar si no està completa";
    public int CurrentAmount = 0;
    public int RequiredAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ultimate slayer assigned");
        QuestName = "NAU 101";
        Description = "La nau no pot engegar si no està completa";

        //ItemReward = "Destral";

        Goals.Add(new CollectionGoal(this, ItemName, Explanation, false, CurrentAmount, RequiredAmount));
        Goals.ForEach(g => g.Init());
    }
}
