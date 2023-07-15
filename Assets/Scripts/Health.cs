using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    
    private int _currentHealth;
    
    public event Action<float, float> OnUpdate;

    private void Start()
    {
        _currentHealth = maxHealth;
        OnUpdate?.Invoke(maxHealth, maxHealth);
    }

    public void TakeDamage(int damage)
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

    protected virtual void Die()
    {
        Debug.Log("Player is dead");
        GameManager.Instance.RemovePlayer(GetComponent<Player>());
        Destroy(gameObject);
    }
}
