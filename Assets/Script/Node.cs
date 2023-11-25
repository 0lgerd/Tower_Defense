using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    public BuildManager buildManager;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        try
        {
            rend = GetComponent<Renderer>();
            startColor = rend.material.color;

            buildManager = FindObjectOfType<BuildManager>();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Start(): {ex.Message}");
        }
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        try
        {
            // Check if clicking on UI
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            // Select the node if it has a turret
            if (turret != null)
            {
                buildManager.SelectNode(this);
                return;
            }

            // Build turret on the node
            if (!buildManager.CanBuild)
            {
                return;
            }

            BuildTurret(buildManager.GetTurretToBuild());
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in OnMouseDown(): {ex.Message}");
        }
    }

    void BuildTurret(TurretBluePrint blueprint)
    {
        try
        {
            // Check if player has enough money to build
            if (PlayerStats.Money < blueprint.cost)
            {
                return;
            }

            // Deduct money and instantiate turret
            PlayerStats.Money -= blueprint.cost;

            GameObject newTurret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
            turret = newTurret;

            turretBlueprint = blueprint;

            // Instantiate build effect
            GameObject buildEffect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(buildEffect, 5f);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in BuildTurret(): {ex.Message}");
        }
    }

    public void UpgradeTurret()
    {
        try
        {
            // Check if player has enough money to upgrade
            if (PlayerStats.Money < turretBlueprint.upgradeCost)
            {
                return;
            }

            // Deduct money and upgrade turret
            PlayerStats.Money -= turretBlueprint.upgradeCost;

            Destroy(turret);

            GameObject upgradedTurret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
            turret = upgradedTurret;

            // Instantiate build effect
            GameObject buildEffect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(buildEffect, 5f);

            isUpgraded = true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in UpgradeTurret(): {ex.Message}");
        }
    }

    public void SellTurret()
    {
        try
        {
            // Add money and instantiate sell effect
            PlayerStats.Money += turretBlueprint.GetSellAmount();

            GameObject sellEffect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(sellEffect, 5f);

            Destroy(turret);
            turretBlueprint = null;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in SellTurret(): {ex.Message}");
        }
    }

    void OnMouseEnter()
    {
        try
        {
            // Check if over UI
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            // Change node color based on build conditions
            if (!buildManager.CanBuild)
            {
                return;
            }

            if (buildManager.HasMoney)
            {
                rend.material.color = hoverColor;
            }
            else
            {
                rend.material.color = notEnoughMoneyColor;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in OnMouseEnter(): {ex.Message}");
        }
    }

    void OnMouseExit()
    {
        try
        {
            // Reset node color
            rend.material.color = startColor;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in OnMouseExit(): {ex.Message}");
        }
    }
}
