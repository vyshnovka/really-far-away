using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : Interactable
{
    [Header("Answer buttons")]
    [SerializeField]
    private GameObject prompt;

    [Header("Shop and Inventory areas to display after \"YES!\"")]
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private GameObject inventory;

    public override void Interact()
    {
        DialogueManager.instance.StartDialogue(dialogue, this);
    }

    public override void FinishInteraction()
    {
        LevelManager.isAbleToMove = true;

        isDoneTalkingOnce = true;

        prompt.SetActive(true);
    }

    public void Yes()
    {
        DialogueManager.instance.FinishDialogueOrMonologue();

        shop.SetActive(true);
        inventory.SetActive(true);

        prompt.SetActive(false);
    }

    public void No()
    {
        DialogueManager.instance.FinishDialogueOrMonologue();

        prompt.SetActive(false);
    }
}
