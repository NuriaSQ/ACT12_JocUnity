using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.up * direction * speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.y - startPos.y) >= distance)
        {
            direction *= -1;
        }
    }
}