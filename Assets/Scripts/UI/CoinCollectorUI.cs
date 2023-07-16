using TMPro;
using UnityEngine;

public class CoinCollectorUI : MonoBehaviour
{
    [SerializeField] private CoinCollector coinCollector;
    [SerializeField] private TextMeshProUGUI coinCount;

    private void Start()
    {
        coinCollector.OnUpdate += UpdateUI; 
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
