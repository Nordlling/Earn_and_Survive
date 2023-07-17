using System;
using UnityEngine;

public class ShootButtonHandler : MonoBehaviour
{
    public event Action OnShoot;

    public void Attack()
    {
        OnShoot?.Invoke();
    }
}
