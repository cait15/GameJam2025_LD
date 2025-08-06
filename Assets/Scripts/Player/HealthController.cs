using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    public bool tempImmunityActive = false;
    public float invincibilityTime = 0.4f;
    [SerializeField] private HealthbarUI healthBarUI;

    [SerializeField] public float _currentHealth;
    [SerializeField] public float _maxHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        if (healthBarUI == null)
        {
            Debug.LogError("HealthBarUI is not assigned in the Inspector!");
            return;
        }

        if (tempImmunityActive == false)
        {
            _currentHealth -= damage;
            tempImmunityActive = true;
            Debug.Log("Health: " + _currentHealth);
            StartCoroutine(Invincibility());

            // Update the health bar
            Debug.Log("Updating health bar...");
            healthBarUI.UpdateHealthBar(this);
        }

        if (_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (healthBarUI == null)
        {
            Debug.LogError("HealthBarUI is not assigned in the Inspector!");
            return;
        }

        if (_currentHealth == _maxHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        // Update the health bar
        healthBarUI.UpdateHealthBar(this);
    }

    IEnumerator Invincibility()
    {
        yield return new WaitForSeconds(invincibilityTime);
        tempImmunityActive = false;
    }
}
