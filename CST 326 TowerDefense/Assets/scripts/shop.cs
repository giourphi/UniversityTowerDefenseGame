using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{

    public TurretBlueprint standardturret;
    public TurretBlueprint missleLauncher;
     BuildMaster buildMaster;

      void Start()
      {
          buildMaster = BuildMaster.instance;
      }

     public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildMaster.SelectTurretToBuild(standardturret);
    }


    public void SelectMissleLauncher()
    {
        Debug.Log("Standard Turret Purchased");
    }
    
}
