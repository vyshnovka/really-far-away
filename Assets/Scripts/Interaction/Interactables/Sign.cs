public class Sign : Interactable
{
    public override void Interact()
    {
        DialogueManager.instance.StartMonologue(dialogue, this);
    }

    public override void FinishInteraction()
    {
        LevelManager.isAbleToMove = true;

        DialogueManager.instance.FinishDialogueOrMonologue();
    }
}
