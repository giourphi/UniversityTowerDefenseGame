using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMaster : MonoBehaviour
{
    public static BuildMaster instance;

     void Awake()
     {
         if (instance != null)
         {
             Debug.LogError("More than one buildmanager in scene!");
             return; 
         }
         instance = this;
         
     }

     public GameObject anotherTurretPrefab;
    public GameObject standardTurretPrefab;
    private TurretBlueprint turretToBuild;


    public  bool CanBuild
    {
        get { return turretToBuild != null; }
    }
    public  bool HasMoney
    {
        get { return PlayerStats.Money >=turretToBuild.cost; }
    }
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("not enough money to build turret");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
       GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
       node.turret = turret;
       
       Debug.Log("money left: "+ PlayerStats.Money);
    }
    
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
