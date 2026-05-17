using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Vector3 startPos = new Vector3(-6.27f, -3.334f, 0f);

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public Vector3 GetStartPosition()
    {
        return startPos;
    }
}