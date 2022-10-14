using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable
{
    public override void Interact()
    {
        DialogueManager.instance.StartMonologue(dialogue, this);
    }

    public override void FinishInteraction()
    {
        DialogueManager.instance.FinishDialogueOrMonologue();
    }
}
