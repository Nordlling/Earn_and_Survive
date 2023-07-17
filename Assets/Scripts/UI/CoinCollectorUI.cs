using TMPro;
using UnityEngine;

public class CoinCollectorUI : MonoBehaviour
{
    [SerializeField] private CoinCollector coinCollector;
    [SerializeField] private TextMeshProUGUI coinCount;

    private bool _subscribed;

    private void Update()
    {
       Subscribe(); 
    }

    private void Subscribe()
    {
        if (_subscribed || GameManager.Instance.CurrentPlayer == null)
        {
            return;
        }

        CoinCollector player = GameManager.Instance.CurrentPlayer.GetComponent<CoinCollector>();
        player.OnUpdate += UpdateUI;
        _subscribed = true;
    }

    private void UpdateUI(CoinCollector coinCollector)
    {
        coinCount.text = coinCollector.CoinCount.ToString();
    }

    private void OnDestroy()
    {
        if (coinCollector != null)
        {
            coinCollector.OnUpdate -= UpdateUI;
        }
    }
}
