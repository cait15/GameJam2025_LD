using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static int sceneNo;
    public GameObject pauseMenuUI; // Reference to the pause menu UI

    public GameObject guideUI; // Reference to the guide UI\

    public GameObject optionsUI;

    public static void LoadScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public void Resume(){
        Time.timeScale = 1f; // Resume the game by setting time scale back to normal
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
    }

    public void Pause(){
        Time.timeScale = 0f; // Pause the game by setting time scale to zero
        pauseMenuUI.SetActive(true); // Show the pause menu UI
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Resume the game before loading the main menu
        SceneManager.LoadScene(0); // Load the main menu scene (assuming it's at index 0)
    }

    public void LoadGuide()
    {
        guideUI.SetActive(true); // Show the guide UI
    }

    public void CloseGuide()
    {
        guideUI.SetActive(false); // Hide the guide UI
    }

    public void OpenOptions()
    {
        optionsUI.SetActive(true); // Show the options UI
    }

    public void CloseOptions()
    {
        optionsUI.SetActive(false); // Hide the options UI
    }

}
