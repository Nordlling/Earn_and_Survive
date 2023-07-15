using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get; private set; }
    private void Start()
    {
        Name = GetInstanceID().ToString();
        GameManager.Instance.AddPlayer(this);
    }
}
