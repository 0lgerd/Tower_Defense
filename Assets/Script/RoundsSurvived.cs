using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    // Start the text animation when the object is enabled
    void OnEnable()
    {
        try
        {
            StartCoroutine(AnimateText());
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in OnEnable(): {ex.Message}");
        }
    }

    // Coroutine to animate the text
    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        // Delay before starting the animation
        yield return new WaitForSeconds(.7f);

        // Increment the round and update the text with a slight delay
        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);


        }
    }
}