using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public event Action<CoinCollector> OnUpdate;
    public int CoinCount { get; private set; }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            AddCoin(1);
            Debug.Log("Coin is taken. Collected coins: " + CoinCount);
        }
    }
    
    private void AddCoin(int count)
    {
        CoinCount += count;
        OnUpdate?.Invoke(this);
    }
}
