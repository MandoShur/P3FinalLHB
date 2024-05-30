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
        SceneManager.LoadScene("Castle Crash");
    }



    public void QuitGame()
    {
        // Quit the application
        UnityEngine.Application.Quit();
        UnityEngine.Debug.Log("Quit button clicked");
    }
}
