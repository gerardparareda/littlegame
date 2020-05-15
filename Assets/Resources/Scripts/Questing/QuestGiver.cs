using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;

    private Quest Quest { get; set; }

    public string[] afterCompleted;
    public string[] completedMission;
    public string[] whileNoCompleted;



    public override void Interact()
    {
        base.Interact();
        if (!AssignedQuest && !Helped)
        {
            AssignQuest();
        } else if (AssignedQuest && !Helped)
        {
            CheckQuest();
        } else
        {
            DialogueSystem.Instance.AddNewDialogue(afterCompleted, name);
        }
    }

    void AssignQuest ()
    {
        AssignedQuest = true;
        
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
        
    }

    void CheckQuest ()
    {
        Debug.Log("CheckQuest" + Quest.Completed);
        Quest.CheckGoals();
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Quest.DeliverObjects();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(completedMission, name);
            //bool itemPickedUp = Inventory.instance.Remove(item);

        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(whileNoCompleted, name);
        }
    }
}
