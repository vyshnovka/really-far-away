using UnityEngine;

public class ExitClosed : Interactable
{
    public override void Interact() { }

    public override void FinishInteraction()
    {
        LevelManager.isAbleToMove = true;

        DialogueManager.instance.FinishDialogueOrMonologue();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LevelManager.isWearingFullSet)
        {
            LevelManager.hasTouchedEndline = true;
            GetComponent<Collider2D>().isTrigger = true;
            return;
        }

        DialogueManager.instance.StartMonologue(dialogue, this);
    }
}
