using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageUpgrade : MonoBehaviour
{

    [SerializeField] private  Boss1Controller boss1Controller;

    [SerializeField] private HealthController playerHealthController;

    [SerializeField] private GameObject upgradeScreen; // Reference to the upgrade screen UI

    public string currentLevel;

    public void UpgradeHealth()
    {
        playerHealthController._maxHealth += 10f; // Increase player max health by 10
        playerHealthController._currentHealth = playerHealthController._maxHealth; // Restore health to max after upgrade
        boss1Controller.damage -= 5f; // Decrease boss damage by 5


        currentLevel = SceneManager.GetActiveScene().name; // Load the win scene after upgrade
        LoadLevel(); // Load the next level
    }

    public void UpgradeDamage()
    {
        boss1Controller.damage += 10f; // Increase boss damage by 5
        playerHealthController._maxHealth -= 5f; // Decrease player max health by 5

         currentLevel = SceneManager.GetActiveScene().name; 
        LoadLevel();
    }

    public void LoadLevel()
    {
        if (currentLevel == "level one setup")
        {
            SceneManager.LoadScene("level two setup"); // Load Level 2
        }
        else if (currentLevel == "level two setup")
        {
            SceneManager.LoadScene("level three setup"); // Load Level 3
        }
        else if (currentLevel == "level three setup")
        {
            SceneManager.LoadScene("WinDemoScene"); // Load Level 4
        }
        upgradeScreen.SetActive(false); // Hide the upgrade screen after loading the next level
    }
}
