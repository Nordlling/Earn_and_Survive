using Photon.Pun;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform point;
    private ShootButtonHandler _shootButtonHandler;
    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _shootButtonHandler = GameManager.Instance.GetShootButtonHandler();
        _shootButtonHandler.OnShoot += Attack;
    }

    public void Attack()
    {
        if (_photonView.IsMine)
        {
            PhotonNetwork.Instantiate(bulletPrefab.name, point.position, point.rotation);
        }
    }

    private void OnDestroy()
    {
        if (_shootButtonHandler != null)
        {
            _shootButtonHandler.OnShoot -= Attack;
        }
    }
}
