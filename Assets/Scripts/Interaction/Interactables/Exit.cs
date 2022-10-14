using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : Interactable
{
    public override void Interact()
    {

    }

    public override void FinishInteraction()
    {
        LevelManager.isAbleToMove = true;

        DialogueManager.instance.FinishDialogueOrMonologue();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DialogueManager.instance.StartMonologue(dialogue, this);
    }
}
