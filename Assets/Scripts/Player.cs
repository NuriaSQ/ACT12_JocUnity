using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 12f;

    public float invincibilityTime = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isInvincible;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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

    public void TakeDamage()
    {
        if (isInvincible) return;

        LifeManager.Instance.TakeDamage(1);
        StartCoroutine(Invincibility());
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;

        float timer = 0f;

        while (timer < invincibilityTime)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
        }

        sr.enabled = true;
        isInvincible = false;
    }
}