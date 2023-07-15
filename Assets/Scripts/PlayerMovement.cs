using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private FixedJoystick _joystick;
    private Weapon _weapon;


    private void Start()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {

        if (_joystick == null)
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
        
        // KEYBOARD
        // float moveX = Input.GetAxis("Horizontal");
        // float moveY = Input.GetAxis("Vertical");
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     if (_weapon != null)
        //     {
        //         _weapon.Attack();
        //     }
        // }
    }
}
