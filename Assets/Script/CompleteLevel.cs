using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuScene = "MainMenu";

    public SceneFader sceneFader;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    // Continue to the next level
    public void Continue()
    {
        try
        {
            // Set the level reached in PlayerPrefs and fade to the next level
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
            sceneFader.FadeTo(nextLevel);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Continue(): {ex.Message}");
        }
    }

    // Return to the main menu
    public void Menu()
    {
        try
        {
            // Fade to the main menu scene
            sceneFader.FadeTo(menuScene);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Menu(): {ex.Message}");
        }
    }
}
