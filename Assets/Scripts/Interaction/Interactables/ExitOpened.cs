using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class ExitOpened : Interactable
{
    [Header("Answer buttons")]
    [SerializeField]
    private GameObject prompt;
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;

    [SerializeField]
    private SpriteLibraryAsset makeupLibrary;
    [SerializeField]
    private SpriteLibrary makeupObject;

    private bool hasMakeup = false;

    public override void Interact() { }

    public override void FinishInteraction()
    {
        LevelManager.isAbleToMove = true;

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(YesEnd);
        noButton.onClick.AddListener(NoEnd);

        prompt.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasMakeup)
        {
            DialogueManager.instance.StartDialogue(dialogue, this);
        }
    }

    private void YesEnd()
    {
        hasMakeup = true;

        makeupObject.spriteLibraryAsset = makeupLibrary;

        LevelManager.isAbleToMove = true;

        DialogueManager.instance.FinishDialogueOrMonologue();

        prompt.SetActive(false);
    }

    private void NoEnd()
    {
        LevelManager.isAbleToMove = true;

        DialogueManager.instance.FinishDialogueOrMonologue();

        prompt.SetActive(false);
    }
}
