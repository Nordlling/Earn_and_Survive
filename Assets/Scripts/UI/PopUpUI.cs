using TMPro;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] private GameObject panel;
    
    private float _healthValue;
    
    private void Start()
    {
        GameManager.Instance.Finished += DisplayWinner;
    }
    
    public void DisplayWinner(int coins, string playerName)
    {
        panel.SetActive(true);
        this.playerName.text = playerName;
        this.coins.text = coins.ToString();
    }
    
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Finished -= DisplayWinner;
        }
    }
}
