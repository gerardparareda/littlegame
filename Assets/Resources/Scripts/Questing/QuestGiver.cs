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
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for your help that one time" }, name);
        }
    }

    void AssignQuest ()
    {
        AssignedQuest = true;
        QuestCounter.numberOfActiveQuest++;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
        

    }

    void CheckQuest ()
    {
        Debug.Log("CheckQuest" + Quest.Completed);
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Quest.DeliverObjects();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for that, here´s your reward.", "More dialogue" }, name);
            //bool itemPickedUp = Inventory.instance.Remove(item);

        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Don't worry, I'll wait for you to complete the mission.", "More dialogue" }, name);
        }
    }
}
