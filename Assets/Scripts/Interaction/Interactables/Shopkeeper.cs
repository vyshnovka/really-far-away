using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : Interactable
{
    [Header("Answer buttons")]
    [SerializeField]
    private GameObject prompt;
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;

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
        isDoneTalkingOnce = true;

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(Yes);
        noButton.onClick.AddListener(No);

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
        LevelManager.isAbleToMove = true;

        DialogueManager.instance.FinishDialogueOrMonologue();

        prompt.SetActive(false);
    }
}
