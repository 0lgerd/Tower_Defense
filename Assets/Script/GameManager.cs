using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver; 

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start ()
    {
        try
        {
            // Set the initial state of the game
            GameIsOver = false;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Start(): {ex.Message}");
        }
    }

    void Update()
    {
        try
        {
            // Check game over conditions
            if (GameIsOver)
            {
                return;
            }

            // End the game if player lives reach zero
            if (PlayerStats.Lives <= 0)
            {
                EndGame();
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Update(): {ex.Message}");
        }
    }

    void EndGame()
    {
        try
        {
            // Set game over state and activate the game over UI
            GameIsOver = true;
            gameOverUI.SetActive(true);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in EndGame(): {ex.Message}");
        }
    }

    // Win the level and activate the complete level UI
    public void WinLevel()
    {
        try
        {
            GameIsOver = true;
            completeLevelUI.SetActive(true);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in WinLevel(): {ex.Message}");
        }
    }
}
