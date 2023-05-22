using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    public abstract void FinishInteraction();

    public Dialogue dialogue;

    [NonSerialized]
    public bool isDoneTalkingOnce = false;
}
