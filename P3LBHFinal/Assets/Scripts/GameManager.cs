using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private PlayerController playerController;
    public UnityEngine.UI.Text enemiesKilledText;

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
    


 

}
