using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("MainGameScene"); // Replace "MainGameScene" with the name of your game scene
    }



    public void QuitGame()
    {
        // Quit the application
        UnityEngine.Application.Quit();
        UnityEngine.Debug.Log("Quit button clicked");
    }
}
