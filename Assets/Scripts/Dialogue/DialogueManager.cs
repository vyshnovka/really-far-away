using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("Children from Dialogue Area")]
    [SerializeField]
    private GameObject dialogueBubble;
    [SerializeField]
    private GameObject characterBubble;
    [SerializeField]
    private GameObject opponentBubble;
    [SerializeField]
    private Image opponentImage;
    [SerializeField]
    private TextMeshProUGUI text;

    private float timeToWait = 0.1f;

    private int lineIndex = 0;
    private string lineToDisplay = "";
    private string partToDisplay = "";

    private Coroutine coroutine;
    private bool isTyping = false;

    private Dialogue dialogueToDisplay;

    private Interactable objectOfInteraction;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }

        instance = this;
    }

    void Update()
    {
        if (dialogueToDisplay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isTyping)
                {
                    isTyping = false;
                    StopCoroutine(coroutine);

                    text.text = lineToDisplay;
                }
                else
                {
                    if (lineIndex < dialogueToDisplay.lines.Count - 1)
                    {
                        lineIndex++;
                        lineToDisplay = dialogueToDisplay.lines[lineIndex];

                        coroutine = StartCoroutine(TextWritter(lineToDisplay));
                    }
                    else
                    {
                        dialogueToDisplay = null;

                        objectOfInteraction.FinishInteraction();
                    }
                }
            }
        }
    }

    public void StartDialogue(Dialogue dialogue, Interactable that)
    {
        dialogueBubble.SetActive(true);
        characterBubble.SetActive(true);
        opponentBubble.SetActive(true);
        opponentImage.sprite = dialogue.opponent;

        objectOfInteraction = that;

        SetDialogueValue(dialogue);
    }

    public void StartMonologue(Dialogue dialogue, Interactable that)
    {
        dialogueBubble.SetActive(true);
        characterBubble.SetActive(true);

        objectOfInteraction = that;

        SetDialogueValue(dialogue);
    }

    private void SetDialogueValue(Dialogue dialogue)
    {
        LevelManager.isAbleToMove = false;

        dialogueToDisplay = dialogue;

        isTyping = true;

        if (objectOfInteraction.isDoneTalkingOnce)
        {
            lineIndex = dialogueToDisplay.lines.Count - 1;
        }
        else
        {
            lineIndex = 0;
        }
        lineToDisplay = dialogueToDisplay.lines[lineIndex];

        coroutine = StartCoroutine(TextWritter(lineToDisplay));
    }

    public void FinishDialogueOrMonologue()
    {
        dialogueBubble.SetActive(false);
        characterBubble.SetActive(false);
        opponentBubble.SetActive(false);
    }

    private IEnumerator TextWritter(string line)
    {
        lineToDisplay = line;
        isTyping = true;

        for (int i = 0; i <= line.Length; i++)
        {
            partToDisplay = line.Substring(0, i);
            text.text = partToDisplay;

            yield return new WaitForSeconds(timeToWait);
        }

        isTyping = false;
        StopCoroutine(coroutine);
    }
}
