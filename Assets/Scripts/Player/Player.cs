using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get; private set; }

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color fieldColor;
    [SerializeField] private float colorOffset = 1f;
    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (_photonView.IsMine)
        {
            Name = PhotonNetwork.NickName;
        }

        GameManager.Instance.AddPlayer(this);

        Color playerColor;
        do
        {
            playerColor = new Color(Random.value, Random.value, Random.value);
        } while (ColorDistance(playerColor, fieldColor) < colorOffset);

        spriteRenderer.color = playerColor;
    }

    private float ColorDistance(Color color1, Color color2)
    {
        return Mathf.Sqrt(Mathf.Pow(color1.r - color2.r, 2) +
                          Mathf.Pow(color1.g - color2.g, 2) +
                          Mathf.Pow(color1.b - color2.b, 2));
    }
}
