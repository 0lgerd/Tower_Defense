using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBluePrint turretToBuild;

    public int _turretToBuild
    {
        get => turretToBuild.cost;
    }
    private Node selectedNode;

    public NodeUI nodeUI;

    void Awake()
    {
        try
        {
            // Check if an instance already exists
            if (instance != null)
            {
                return;
            }

            instance = this;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in Awake(): {ex.Message}");
        }
    }

    // Check if a turret can be built
    public bool CanBuild 
    { 
        get 
        {
            try
            {
                return turretToBuild != null;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error in CanBuild property: {ex.Message}");
                return false;
            }
        } 
    }
    
    // Check if the player has enough money to build the selected turret
    public bool HasMoney 
    { 
        get 
        {
            try
            {
                return PlayerStats.Money >= turretToBuild.cost;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error in HasMoney property: {ex.Message}");
                return false;
            }
        } 
    }

    // Set the turret to build
    public void SetTurretToBuild(TurretBluePrint turretBlueprint)
    {
        try
        {
            turretToBuild = turretBlueprint;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in SetTurretToBuild(): {ex.Message}");
        }
    }

    // Select a node for building or interaction
    public void SelectNode (Node node)
    {
        try
        {
            // Deselect if the same node is clicked again
            if(selectedNode == node)
            {
                DeselectNode();
                return;
            }

            selectedNode = node;
            turretToBuild = null;

            // Set the target for the Node UI
            nodeUI.SetTarget(node);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in SelectNode(): {ex.Message}");
        }
    }

    // Deselect the currently selected node
    public void DeselectNode()
    {
        try
        {
            selectedNode = null;
            nodeUI.Hide();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in DeselectNode(): {ex.Message}");
        }
    }

    // Select a turret to build
    public void SelectToBuild(TurretBluePrint turretBlueprint)
    {
        try
        {
            turretToBuild = turretBlueprint;
            
            // Deselect the current node
            DeselectNode();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in SelectToBuild(): {ex.Message}");
        }
    }

    // Get the turret to build
    public TurretBluePrint GetTurretToBuild()
    {
        try
        {
            return turretToBuild;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error in GetTurretToBuild(): {ex.Message}");
            return null;
        }
    }
}
