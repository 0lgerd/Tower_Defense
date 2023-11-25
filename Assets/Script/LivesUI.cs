using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    void Update()
    {
        try
        {
            // Update the lives text based on the player's remaining lives
            livesText.text = PlayerStats.Lives + " Lives";
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Update(): {ex.Message}");
        }
    }
}
