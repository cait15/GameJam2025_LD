using System;
using UnityEngine;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _healthBarForegroundImage;

    public void UpdateHealthBar(HealthController healthController)
    {
        Debug.Log("BITCH");
        _healthBarForegroundImage.fillAmount = healthController.RemainingHealthPercentage;
    }
}
