using System.Collections;
using UnityEngine;

public class WalkerEnemy : MonoBehaviour
{
    public float speed = 2f;
    public float leftTime = 2f;
    public float rightTime = 4f;

    private int direction = -1;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(MoveRoutine());
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        if (direction > 0)
            sr.flipX = true;
        else if (direction < 0)
            sr.flipX = false;
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            direction = -1;
            yield return new WaitForSeconds(leftTime);

            direction = 1;
            yield return new WaitForSeconds(rightTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y <= -0.5f)
                {
                    Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 7f);

                    Destroy(gameObject);
                    return;
                }
                else
                {
                    collision.gameObject.GetComponent<Player>().TakeDamage();
                    return;
                }
            }
        }
    }
}