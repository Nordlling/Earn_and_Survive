using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance{get; private set;}

    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private ShootButtonHandler shootButtonHandler;
    
    public List<Player> LivePlayers { get; private set; }
    public List<Player> DeadPlayers { get; private set; }
    public List<GameObject> Coins { get; private set; }
    
    public GameObject CurrentPlayer { get; set; }
    public bool IsStarted { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        LivePlayers = new List<Player>();
        DeadPlayers = new List<Player>();
        Coins = new List<GameObject>();
        PhotonNetwork.AutomaticallySyncScene = true;
        Instance = this;
    }

    private void Update()
    {
        if (!IsStarted && LivePlayers.Count > 1)
        {
            IsStarted = true;
        }
        else if (IsStarted && LivePlayers.Count == 1)
        {
            IsStarted = false;
            FinishGame();
        }
    }

    private void FinishGame()
    {
        string playerName = LivePlayers[0].Name;
        if (!string.IsNullOrEmpty(playerName))
        {
            int coinCount = LivePlayers[0].GetComponent<CoinCollector>().CoinCount;
            ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
            playerProperties["Name"] = playerName;
            playerProperties["Coins"] = coinCount;
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        }
        Invoke(nameof(RestartLevel), 3f);
    }
    
    private void RestartLevel()
    {
        foreach (var coin in Coins)
        {
            PhotonNetwork.Destroy(coin);
        }
        PhotonNetwork.Destroy(LivePlayers[0].gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void AddCoin(GameObject coin)
    {
        Coins.Add(coin);
    }
    
    public void RemoveCoin(GameObject coin)
    {
        Coins.Remove(coin);
    }

    public void AddPlayer(Player player)
    {
        LivePlayers.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        LivePlayers.Remove(player);
        DeadPlayers.Remove(player);
    }
    
    public void KillPlayer(Player player)
    {
        LivePlayers.Remove(player);
        DeadPlayers.Add(player);
    }

    public FixedJoystick GetJoystick()
    {
        return joystick;
    }
    
    public ShootButtonHandler GetShootButtonHandler()
    {
        return shootButtonHandler;
    }
    
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("Player " + newPlayer.NickName + " connected.");
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log("Player " + otherPlayer.NickName + " disconnected.");
    }
}