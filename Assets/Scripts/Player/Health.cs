using System;
using Photon.Pun;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    
    private int _currentHealth;
    private PhotonView _photonView;
    
    public event Action<float, float> OnUpdate;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (_photonView.IsMine)
        {
            GameManager.Instance.CurrentPlayer = gameObject;
        }
        _currentHealth = maxHealth;
        Invoke(nameof(SendMaxHealth), 0.1f);
    }

    private void SendMaxHealth()
    {
        if (_photonView.IsMine)
        {
            OnUpdate?.Invoke(maxHealth, maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (_photonView.IsMine)
        {
            if (damage < 0)
            {
                throw new Exception("Negative damage");
            }

            _currentHealth -= damage;
            OnUpdate?.Invoke(_currentHealth, maxHealth);

            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        GameManager.Instance.KillPlayer(GetComponent<Player>());
        PhotonNetwork.Destroy(gameObject);
    }
    
    private void OnDestroy()
    {
        GameManager.Instance.RemovePlayer(GetComponent<Player>());
    }
}
