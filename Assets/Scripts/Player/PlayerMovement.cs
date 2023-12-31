using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    // [SerializeField] private FixedJoystick _joystick;
    private FixedJoystick _joystick;
    private Weapon _weapon;
    private PhotonView _photonView;


    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _joystick = GameManager.Instance.GetJoystick();
        _weapon = GetComponent<Weapon>();
    }

    private void LateUpdate()
    {
        if (!_photonView.IsMine)
        {
            Destroy(this);
            return;
        }

        if (_joystick == null || !GameManager.Instance.IsStarted)
        {
            return;
        }

        float moveX = _joystick.Horizontal;
        float moveY = _joystick.Vertical;

        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        transform.position += movement;

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        }
    }
}
