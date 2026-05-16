using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int Amount { get; private set; }

    public Action<int> OnCoinChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoin(int value)
    {
        Amount += value;
        OnCoinChanged?.Invoke(Amount);
    }
}