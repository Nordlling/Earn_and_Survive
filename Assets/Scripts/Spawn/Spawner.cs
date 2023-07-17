using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected Transform heightMin;
    [SerializeField] protected Transform heightMax;
    [SerializeField] protected float offset = 5f;
    
    protected Vector2 _borderMin;
    protected Vector2 _borderMax;
    

    protected virtual void FillBorders()
    {
        var mainCamera = Camera.main;
        if (mainCamera != null)
        {
            _borderMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
            _borderMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

            _borderMin.x += offset;
            _borderMax.x -= offset;
            _borderMin.y = heightMin.position.y + offset;
            _borderMax.y = heightMax.position.y - offset;
        }
    }
    
    protected virtual void Spawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(_borderMin.x, _borderMax.x), Random.Range(_borderMin.y, _borderMax.y));
        PhotonNetwork.Instantiate(prefab.name, spawnPosition, Quaternion.identity);
    }
}
