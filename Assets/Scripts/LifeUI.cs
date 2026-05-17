using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Image[] hearts;

    private void Start()
    {
        LifeManager.Instance.OnLivesChanged += UpdateHearts;
        UpdateHearts(LifeManager.Instance.lives);
    }

    void UpdateHearts(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lives;
        }
    }
}