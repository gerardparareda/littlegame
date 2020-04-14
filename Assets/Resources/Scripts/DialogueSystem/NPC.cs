using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string NPC_name;

    public override void Interact()
    {
        Debug.Log("Interaccionant amb NPC");
        DialogueSystem.Instance.AddNewDialogue(dialogue, NPC_name);
    }
}
