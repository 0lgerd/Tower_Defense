using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;

    public string mainMenu = "MainMenu";

    // Retry the current level
    public void Retry()
    {
        try
        {
            sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Retry(): {ex.Message}");
        }
    }

    // Return to the main menu
    public void Menu()
    {
        try
        {
            sceneFader.FadeTo(mainMenu);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Menu(): {ex.Message}");
        }
    }
}
