using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standartTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint Laser;

    BuildManager buildManager;

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
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in SelectLaser(): {ex.Message}");
        }
    }
}
