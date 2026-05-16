using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    public TMP_Text text;

    private void Start()
    {
        if (CoinManager.Instance == null)
        {
            Debug.LogError("No existe CoinManager en la escena");
            return;
        }

        CoinManager.Instance.OnCoinChanged += UpdateText;
        UpdateText(CoinManager.Instance.Amount);
    }

    private void OnDisable()
    {
        if (CoinManager.Instance != null)
            CoinManager.Instance.OnCoinChanged -= UpdateText;
    }

    void UpdateText(int amount)
    {
        text.text = "Coins: " + amount;
    }
}