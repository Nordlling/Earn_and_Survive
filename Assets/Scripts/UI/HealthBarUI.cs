using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _lerpSpeed = 2;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthText;
    
    private float _healthValue;
    
    private void Start()
    {
        _health.OnUpdate += UpdateHealthBar; 
        _healthValue = 1;
        _healthSlider.value = 1;
    }

    private void Update()
    {
        _healthSlider.value = Mathf.Lerp(_healthSlider.value, _healthValue, _lerpSpeed * Time.deltaTime);
    }
    
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        _healthValue = Mathf.Clamp01(currentHealth / maxHealth);
        _healthText.text = Mathf.Max((int)currentHealth, 0) + "/" + (int)maxHealth;
    }
    
    private void OnDestroy()
    {
        if (_health != null)
        {
            _health.OnUpdate -= UpdateHealthBar;
        }
    }
}
