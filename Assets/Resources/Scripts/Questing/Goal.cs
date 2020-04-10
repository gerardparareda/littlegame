using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{

    public Quest Quest { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }
    public string ItemID { get; set; }
    public virtual void Init ()
    {
        //default init stuff
    }

    public void Evaluate ()
    {
        Debug.Log(CurrentAmount + " vs " + RequiredAmount);
        if (CurrentAmount >= RequiredAmount) {

            Complete();
        }
    }

    public void Complete() {
        Completed = true;
        Quest.CheckGoals();   
        Debug.Log("Completed" + Completed);
    }
}
