using System;
using Photon.Pun;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public event Action<CoinCollector> OnUpdate;
    public int CoinCount { get; private set; }
    
    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin") && col.gameObject.activeSelf)
        {
            col.gameObject.SetActive(false);
            GameManager.Instance.RemoveCoin(gameObject);
            PhotonNetwork.Destroy(col.gameObject);
            if (GameManager.Instance.IsStarted)
            {
                AddCoin(1);
            }
        }
    }
    
    private void AddCoin(int count)
    {
        CoinCount += count;
        if (_photonView.IsMine)
        {
            OnUpdate?.Invoke(this);
        }
    }
}
