using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text.Json;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standartTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint Laser;

    BuildManager buildManager;

    public int counter_weapon;
    public int count_weapon;

    // Initialize BuildManager on start
    void Start()
    {
        try
        {
            buildManager = BuildManager.instance;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Start(): {ex.Message}");
        }
    }

    // Select the standard turret for building
    public void SelectStandartTurrel()
    {
        try
        {
            buildManager.SelectToBuild(standartTurret);
            counter_weapon=+turretToBuild.cost;
            count_weapon++;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in SelectStandartTurrel(): {ex.Message}");
        }
    }

    // Select the missile launcher for building
    public void SelectMissileLauncehr()
    {
        try
        {
            buildManager.SelectToBuild(missileLauncher);
            counter_weapon=+turretToBuild.cost;
            count_weapon++;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in SelectMissileLauncehr(): {ex.Message}");
        }
    }

    // Select the laser for building
    public void SelectLaser()
    {
        try
        {
            buildManager.SelectToBuild(Laser);
            counter_weapon=+turretToBuild.cost;
            count_weapon++;

        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in SelectLaser(): {ex.Message}");
        }
    }

    string jsonString = JsonSerializer.Serialize(counter_weapon, new JsonSerializerOptions)
        {
            WriteIndented = true 
        });

        File.WriteAllText("data.json", jsonString);

         string jsonString2 = JsonSerializer.Serialize(count_weapon, new JsonSerializerOptions)
        {
            WriteIndented = true 
        });

        File.WriteAllText("data.json", jsonString2);
}
