public class Apple : Interactable
{
    public override void Interact()
    {
        DialogueManager.instance.StartMonologue(dialogue, this);
    }

    public override void FinishInteraction()
    {
        MoneyManager.instance.SetCash(10);

        LevelManager.isAbleToMove = true;

        DialogueManager.instance.FinishDialogueOrMonologue();

        this.transform.parent.gameObject.SetActive(false);
    }
}
