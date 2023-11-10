using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standartTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint Laser;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurrel()
    {
        buildManager.SelectToBuild(standartTurret);
    }
    public void SelectMissileLauncehr()
    {
        buildManager.SelectToBuild(missileLauncher);
    }

    public void SelectLaser()
    {
        buildManager.SelectToBuild(Laser);
    }


}
