using UnityEngine;

public class ClothesController : Animatable
{
    protected override void HandleInputs()
    {
        movementDirection.x = Input.GetButton("Horizontal") ? Input.GetAxis("Horizontal") : 0;
        movementDirection.y = Input.GetButton("Vertical") ? Input.GetAxis("Vertical") : 0;
    }
}
