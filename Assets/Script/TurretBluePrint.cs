using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        try
        {
            return cost / 2;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in GetSellAmount(): {ex.Message}");
            return 0;
        }
    }
}
