using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : NPC
{
    public int Stage { get; set; } //stage 0, 1, 2, 3
    public bool Helped { get; set; }
    public bool caseActive { get; set; }

    public GameObject part1;
    public GameObject part2;
    public GameObject part3;

    public string[] firstOfAll;
    public string[] completed;
    public string[] completed1;
    public string[] completed2;
    public string[] whileNoCompleted;

    public bool AssignedQuest { get; set; }

    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;

    private Quest Quest { get; set; }

    // Spaceship animations
    public Animator partBaix;
    public Animator partMig;
    public Animator partAlt;


    public void Awake()
    {
        part1.gameObject.SetActive(false);
        part2.gameObject.SetActive(false);
        part3.gameObject.SetActive(false);
        Stage = 0;
        Helped = false;
    }

    public override void Interact()
    {
        Helped = true;

        switch (Stage)
        {
            case 0: 
                if (!caseActive)
                {
                    DialogueSystem.Instance.AddNewDialogue(firstOfAll, name, Picture);
                    caseActive = true;
                    Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
                } else
                {
                    CheckQuest();
                }
                break;
            case 1:
                CheckQuest();

                break;

            case 2:
                CheckQuest();
                
                break;

            case 3:
                if (Helped)
                {

                    Helped = false;
                    Stage = 4;

                    partAlt.SetTrigger("enlairar");
                    partMig.SetTrigger("enlairar");
                    partBaix.SetTrigger("enlairar");




                }
                break;
                
        }
            
    }

    void CheckQuest()
    {
        Debug.Log("CheckQuest" + Quest.Completed);
        if (Quest.Completed)
        {
            Quest.DeliverObjects();

            if (Stage == 0)
            {
                part1.gameObject.SetActive(true);
                DialogueSystem.Instance.AddNewDialogue(completed1, name, Picture);
            }   else if (Stage == 1)
            {
                part2.gameObject.SetActive(true);
                DialogueSystem.Instance.AddNewDialogue(completed2, name, Picture);
            } else
            {
                part3.gameObject.SetActive(true);
                DialogueSystem.Instance.AddNewDialogue(completed, name, Picture);
            }

            Stage += 1;

            Quest = (Quest)quests.AddComponent(System.Type.GetType(questType)); //assignem el quest per a la segona peça

        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(whileNoCompleted, name, Picture);
        }
    }
}
