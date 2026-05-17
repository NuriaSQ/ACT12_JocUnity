using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class FinishLevel : MonoBehaviour
{
    public GameObject finishUI;
    private bool finished;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finishUI.SetActive(true);
            Time.timeScale = 0f;
            finished = true;
        }
    }

    void Update()
    {
        if (!finished) return;

        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}