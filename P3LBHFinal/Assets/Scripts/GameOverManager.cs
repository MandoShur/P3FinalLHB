using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; 
    public TextMeshProUGUI gameOverText; 

    private bool isGameOver = false;

    //trigger gameover
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

        //to quit the app
   
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
       

    }
}