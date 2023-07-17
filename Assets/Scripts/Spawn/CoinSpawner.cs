using Photon.Pun;
using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private int coinCount;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            FillBorders();
            for (int i = 0; i < coinCount; i++)
            {
                Spawn();
            }
        }
    }
}
