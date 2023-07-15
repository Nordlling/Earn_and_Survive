using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int coinCount;
    
    private Camera mainCamera;
    private Vector2 cameraMin;
    private Vector2 cameraMax;

    private void Start()
    {
        mainCamera = Camera.main;
        cameraMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        cameraMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        for (int i = 0; i < coinCount; i++)
        {
            spawnCoin();
        }
    }
    
    private void spawnCoin()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(cameraMin.x, cameraMax.x), Random.Range(cameraMin.y, cameraMax.y));
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
