public class Inventory : Interactable
{
    public override void Interact() { }

    public override void FinishInteraction()
    {
        LevelManager.isAbleToMove = true;

        DialogueManager.instance.FinishDialogueOrMonologue();
    }
}
