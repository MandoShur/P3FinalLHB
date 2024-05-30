using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // If you're using TextMeshPro for UI text

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; // Reference to the game over UI
    public TextMeshProUGUI gameOverText; // Reference to the game over text

    private bool isGameOver = false;

    // Call this method to trigger gameover
    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;
        gameOverUI.SetActive(true);
        gameOverText.text = "Game Over";
        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;

   
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
       

    }
}