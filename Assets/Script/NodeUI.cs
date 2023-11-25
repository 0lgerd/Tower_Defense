using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text upgradeCost;
    public Button upgradeButton;
    public Text sellAmount;

    private Node target;

    // Set the UI target and display relevant information
    public void SetTarget(Node _target)
    {
        try
        {
            target = _target;

            // Position the UI above the node
            transform.position = target.GetBuildPosition();

            // Display upgrade cost and button state
            if (!target.isUpgraded)
            {
                upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
                upgradeButton.interactable = true;
            }
            else
            {
                upgradeCost.text = "Done";
                upgradeButton.interactable = false;
            }

            // Display sell amount
            sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

            // Activate the UI
            ui.SetActive(true);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in SetTarget(): {ex.Message}");
        }
    }

    // Hide the UI
    public void Hide()
    {
        try
        {
            ui.SetActive(false);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Hide(): {ex.Message}");
        }
    }

    // Upgrade the turret and deselect the node
    public void Upgrade()
    {
        try
        {
            target.UpgradeTurret();
            BuildManager.instance.DeselectNode();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Upgrade(): {ex.Message}");
        }
    }

    // Sell the turret and deselect the node
    public void Sell()
    {
        try
        {
            target.SellTurret();
            BuildManager.instance.DeselectNode();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Sell(): {ex.Message}");
        }
    }
}
