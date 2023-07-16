using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private float lerpSpeed = 2;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    
    private float _healthValue;
    
    private void Start()
    {
        health.OnUpdate += UpdateHealthBar; 
        _healthValue = 1;
        healthSlider.value = 1;
    }

    private void Update()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, _healthValue, lerpSpeed * Time.deltaTime);
    }
    
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        _healthValue = Mathf.Clamp01(currentHealth / maxHealth);
        healthText.text = Mathf.Max((int)currentHealth, 0) + "/" + (int)maxHealth;
    }
    
    private void OnDestroy()
    {
        if (health != null)
        {
            health.OnUpdate -= UpdateHealthBar;
        }
    }
}
