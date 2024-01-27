using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public float moveSpeed = 5f;

    void FixedUpdate()
    {
        // Get the horizontal input (left and right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontalInput, 0f);

        // Move the character using Rigidbody
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 movement)
    {
        // Get the Rigidbody component attached to the GameObject
        Rigidbody rb = GetComponent<Rigidbody>();

        // Update the Rigidbody's velocity based on the movement vector
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }
}

