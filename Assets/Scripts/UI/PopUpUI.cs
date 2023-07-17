using Photon.Pun;
using TMPro;
using UnityEngine;

public class PopUpUI : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] private GameObject panel;
    
    private float _healthValue;
    
    private void Start()
    {
        panel.SetActive(false);
    }
    
    private void DisplayWinner(int coins, string playerName)
    {
        panel.SetActive(true);
        this.playerName.text = playerName;
        this.coins.text = coins.ToString();
    }
    
    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (targetPlayer != null) {
            DisplayWinner((int)changedProps["Coins"], (string)changedProps["Name"]);
        }
    }
}
