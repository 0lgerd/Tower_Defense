using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;
    public Button[] levelButtons;

    private void Start()
    {
        try
        {
            // Get the level reached from PlayerPrefs and disable buttons for unreached levels
            int levelReached = PlayerPrefs.GetInt("levelReached", 1);
            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (i + 1 > levelReached)
                    levelButtons[i].interactable = false;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Start(): {ex.Message}");
        }
    }

    // Fade to the selected level
    public void Select(string levelName)
    {
        try
        {
            fader.FadeTo(levelName);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Select(): {ex.Message}");
        }
    }
}
