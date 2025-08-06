using System;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreenUI; // Reference to the death screen UI

    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.gameObject.CompareTag("Player")){
            Time.timeScale = 0f; // Pause the game
            deathScreenUI.SetActive(true); // Show the death screen UI
        }
    }
}
