using System;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;

    public int lives = 3;

    public Action<int> OnLivesChanged;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        lives -= amount;
        lives = Mathf.Max(lives, 0);

        OnLivesChanged?.Invoke(lives);

        if (lives <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}