using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    public SceneFader sceneFader;

    public string menuNameScene = "MainMenu";

    void Update()
    {
        try
        {
            // Toggle the pause menu on Escape or P key press
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                Toggle();
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Update(): {ex.Message}");
        }
    }

    // Toggle the visibility of the pause menu
    public void Toggle()
    {
        try
        {
            ui.SetActive(!ui.activeSelf);

            // Pause or resume the game based on the pause menu visibility
            Time.timeScale = ui.activeSelf ? 0f : 1f;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Toggle(): {ex.Message}");
        }
    }

    // Retry the current level
    public void Retry()
    {
        try
        {
            Toggle();
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
            Toggle();
            sceneFader.FadeTo(menuNameScene);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Menu(): {ex.Message}");
        }
    }
}
