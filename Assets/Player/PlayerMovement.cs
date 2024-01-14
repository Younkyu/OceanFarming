using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine.InputSystem;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public partial class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 smoothMovementInput;
    private Vector2 movementInputSmoothVelocity;

    // FixedUpdate is called every fixed framerate frame, if the MonoBehavior is enabled
    // Physics Calcuations
    void FixedUpdate()
    {
        smoothMovementInput = Vector2.SmoothDamp(smoothMovementInput, moveDirection, ref movementInputSmoothVelocity, 0.1f);
        rb.velocity = smoothMovementInput * movementSpeed;
    }

    void OnMove(InputValue inputValue) {
        moveDirection = inputValue.Get<Vector2>();
    }
}
