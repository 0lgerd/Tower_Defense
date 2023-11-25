using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    void Start()
    {
        try
        {
            // Initialize player stats
            Money = startMoney;
            Lives = startLives;
            Rounds = 0;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Start(): {ex.Message}");
        }
    }
}
