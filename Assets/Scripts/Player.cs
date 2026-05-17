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
    private Animator anim;
    private bool isInvincible;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        transform.position = GameManager.Instance.GetStartPosition();
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

        if (move > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (move < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        Vector2 velocity = rb.linearVelocity;

        velocity.x = move * speed;

        bool isGrounded = Mathf.Abs(rb.linearVelocity.y) < 0.01f;
        bool isJumping = !isGrounded && rb.linearVelocity.y > 0.1f;
        bool isFalling = rb.linearVelocity.y < -0.1f;

        anim.SetBool("isRunning", move != 0);
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isFalling", isFalling);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameObject.activeInHierarchy) return;

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!gameObject.activeInHierarchy) return;

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null);
        }
    }

    private IEnumerator UnparentSafe()
    {
        yield return null;
        transform.SetParent(null);
    }
}