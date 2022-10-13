using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Animatable
{
    [Range(0, 5)]
    public float movementSpeed = 1f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        anim = GetComponent<Animator>();

        movementDirection = Vector2.zero;
    }

    protected override void HandleInputs()
    {
        movementDirection.x = Input.GetButton("Horizontal") ? Input.GetAxis("Horizontal") : 0;
        movementDirection.y = Input.GetButton("Vertical") ? Input.GetAxis("Vertical") : 0;

        rb.velocity = movementDirection.normalized * movementSpeed;
    }
}
