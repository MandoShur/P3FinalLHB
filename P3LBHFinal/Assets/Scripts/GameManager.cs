using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private PlayerController playerController;
    public UnityEngine.UI.Text enemiesKilledText;
    private PlayerMovement playerMovement;
    public Canvas gameOverCanvas;
    public Canvas gameOverScreen;
    public Button restartButton; 
    public Button quitButton;
    public GameObject player;

   



    void Awake()
    {
        // make sure only one instance of the GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Find the player controller in the scene
        playerController = FindObjectOfType<PlayerController>();

        // Disable player movement when at the title screen
        if (SceneManager.GetActiveScene().name == "TitleScreen")
        {
            SetPlayerMovement(false);
        }

      
        if (player == null)
        {
            UnityEngine.Debug.LogError("Player is not assigned in the GameManager.");
        }
        else
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement == null)
            {
                UnityEngine.Debug.LogError("PlayerMovement component is not found on the player GameObject.");
            }
        }

        if (gameOverCanvas == null)
        {
            UnityEngine.Debug.LogError("Game Over Canvas is not assigned in the GameManager.");
        }
        else
        {
            gameOverCanvas.gameObject.SetActive(false); // Ensure Game Over screen is inactive at the start
        }

        if (restartButton == null)
        {
            UnityEngine.Debug.LogError("Restart Button is not assigned in the GameManager.");
        }
        else
        {
            restartButton.onClick.AddListener(RestartGame);
        }

        if (quitButton == null)
        {
            UnityEngine.Debug.LogError("Quit Button is not assigned in the GameManager.");
        }
        else
        {
            quitButton.onClick.AddListener(QuitGame);
        }


    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the player controller again in the new scene
        playerController = FindObjectOfType<PlayerController>();

        // Enable or disable player movement based on the scene
        if (scene.name == "TitleScreen")
        {
            SetPlayerMovement(false);
        }
        else
        {
            SetPlayerMovement(true);
        }
    }

    public void SetPlayerMovement(bool canMove)
    {
        if (playerController != null)
        {
            playerController.SetCanMove(canMove);
        }
    }

    public void GameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.gameObject.SetActive(true); // Activates game over screen
        }
        if (playerMovement != null)
        {
            playerMovement.enabled = false; // Disable movement
        }
    }

    public void RestartGame()
    {
       
        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



     public void QuitGame()
     {
        // Quit the app
        UnityEngine.Application.Quit();

        // If its running in the editor stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
         #endif
     }






}
