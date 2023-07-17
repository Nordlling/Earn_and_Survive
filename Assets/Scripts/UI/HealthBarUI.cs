using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private float lerpSpeed = 2;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    private bool _subscribed;
    private float _healthValue;

    private void Start()
    {
        _healthValue = 1;
        healthSlider.value = 1;
        Subscribe();
    }

    private void Update()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, _healthValue, lerpSpeed * Time.deltaTime);
        Subscribe();
    }
    
    private void Subscribe()
    {
        if (_subscribed || GameManager.Instance.CurrentPlayer == null)
        {
            return;
        }

        Health player = GameManager.Instance.CurrentPlayer.GetComponent<Health>();
        player.OnUpdate += UpdateUI;
        _subscribed = true;
    }
    
    public void UpdateUI(float currentHealth, float maxHealth)
    {
        _healthValue = Mathf.Clamp01(currentHealth / maxHealth);
        healthText.text = Mathf.Max((int)currentHealth, 0) + "/" + (int)maxHealth;
    }
}
