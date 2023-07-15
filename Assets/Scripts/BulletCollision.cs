using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private int damage = 40;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLISION: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Body") )
        {
            var health = other.GetComponentInParent<Health>();
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
