using TMPro;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private GameObject _panel;
    
    private float _healthValue;
    
    private void Start()
    {
        GameManager.Instance.Finished += DisplayWinner;
    }
    
    public void DisplayWinner(int coins, string playerName)
    {
        _panel.SetActive(true);
        _playerName.text = playerName;
        _coins.text = coins.ToString();
    }
    
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Finished -= DisplayWinner;
        }
    }
    
    
}
