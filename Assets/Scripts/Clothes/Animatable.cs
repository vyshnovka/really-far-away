using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Animatable : MonoBehaviour
{
    protected Animator anim;
    protected Vector2 movementDirection;

    void Awake()
    {
        anim = GetComponent<Animator>();

        movementDirection = Vector2.zero;
    }

    void Update()
    {
        HandleInputs();
        HandleAnimation();
    }

    protected abstract void HandleInputs();

    protected void HandleAnimation()
    {
        if (!LevelManager.isAbleToMove)
        {
            anim.SetFloat("X", 0);
            anim.SetFloat("Y", 0);
            return;
        }

        anim.SetFloat("X", movementDirection.x);
        anim.SetFloat("Y", movementDirection.y);
    }
}
