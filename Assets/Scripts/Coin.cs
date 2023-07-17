using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.AddCoin(gameObject);
    }
}
