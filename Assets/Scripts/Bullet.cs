using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 600f;

    private void Start()
    {
        if (!GameManager.Instance.IsStarted)
        {
           Destroy(gameObject); 
        }
    }

    private void Update()
    {
        Vector3 movement = transform.up * speed * Time.deltaTime;
        transform.position += movement; 
    }
}
