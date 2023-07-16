using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner Instance{ get; private set; }
    
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Button shootButton;
    
    private Camera mainCamera;
    private Vector2 cameraMin;
    private Vector2 cameraMax;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        cameraMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        cameraMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
        spawn();
    }
    
    private void spawn()
    {
        ShootButtonHandler shootButtonHandler = shootButton.GetComponent<ShootButtonHandler>();

        if (shootButtonHandler != null)
        {
            shootButton.onClick.AddListener(shootButtonHandler.Attack);
        }
        
        Vector2 spawnPosition = new Vector2(Random.Range(cameraMin.x, cameraMax.x), Random.Range(cameraMin.y, cameraMax.y));
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);

    }
}
