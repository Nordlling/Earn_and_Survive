using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform point;

    public void Attack()
    {
        Instantiate(bulletPrefab, point.position, point.rotation);
    }
}
