using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform point;
    
    public event Action OnShoot;

    public void Attack()
    {
        // PhotonNetwork.Instantiate(bulletPrefab.name, point.position, point.rotation);
        OnShoot?.Invoke();
    }
}
