using UnityEngine;

public class bossHealthBarUI : MonoBehaviour
{

     [SerializeField]
    private UnityEngine.UI.Image _healthBarForegroundImage;
    public void UpdateHealthBar(Boss1Controller healthbar)
    {
        if (_healthBarForegroundImage != null)
        {
            _healthBarForegroundImage.fillAmount = healthbar._health/100f; // Assuming max health is 100
        }
    }
}
