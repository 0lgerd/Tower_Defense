using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBluePrint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SetTurretToBuild(TurretBluePrint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
    }

    public void SelectNode (Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectToBuild(TurretBluePrint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
        
        DeselectNode();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
