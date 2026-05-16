using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                move = -1;

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                move = 1;
        }

        Vector2 velocity = rb.linearVelocity;
        velocity.x = move * speed;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            velocity.y = jumpForce;
        }

        rb.linearVelocity = velocity;
    }
}