using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelLoad = "Level";

    public SceneFader sceneFader;

    // Fade to the specified level
    public void Play()
    {
        try
        {
            sceneFader.FadeTo(levelLoad);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Play(): {ex.Message}");
        }
    }

    // Quit the application
    public void Quit()
    {
        try
        {
            Debug.Log("Exiting...");
            Application.Quit();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Quit(): {ex.Message}");
        }
    }
}
