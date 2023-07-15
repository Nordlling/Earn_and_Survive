using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set;}
    
    private List<Player> _players;
    private bool _isStarted;

    public event Action<int, string> Finished;

    private void Awake()
    {
        _players = new List<Player>();
        Instance = this;
    }

    private void Update()
    {
        if (!_isStarted && _players.Count > 1)
        {
            StartGame();
            _isStarted = true;
        }
        else if (_isStarted && _players.Count < 2)
        {
            FinishGame();
        }
    }

    private void StartGame()
    {
        
    }
    
    private void FinishGame()
    {
        int coinCount = _players[0].GetComponent<CoinCollector>().CoinCount;
        string playerName = _players[0].Name;
        Finished?.Invoke(coinCount, playerName);
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        _players.Remove(player);
    }
}
