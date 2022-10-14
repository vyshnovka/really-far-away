using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : Interactable
{
    public override void Interact()
    {
        DialogueManager.instance.StartMonologue(dialogue, this);
    }

    public override void FinishInteraction()
    {
        LevelManager.instance.isAbleToMove = true;

        DialogueManager.instance.FinishDialogueOrMonologue();
    }
}
