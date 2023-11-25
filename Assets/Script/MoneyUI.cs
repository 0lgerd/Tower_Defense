using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    // Update is called once per frame
    void Update()
    {
        try
        {
            // Update the money text based on the player's money
            moneyText.text = "$" + PlayerStats.Money.ToString();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Update(): {ex.Message}");
        }
    }
}
