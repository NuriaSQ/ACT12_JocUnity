using UnityEngine;

public class FrogEnemy : MonoBehaviour
{
    public float bounceForce = 7f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y <= -0.5f)
                {
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    LifeManager.Instance.TakeDamage(1);
                    return;
                }
            }
        }
    }
}