using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update

    public Color hoverColor;
    public Vector3 positionOffset;
    public Color notEnoughMoneycolor;
    
    [Header("Optional")]
    public GameObject turret;
    
    private Renderer rend;
    private Color startColor;

    BuildMaster buildMaster;
    
     void Start()
     {
         rend = GetComponent<Renderer>();
         startColor = rend.material.color;
         buildMaster = BuildMaster.instance;
     }

     public Vector3 GetBuildPosition()
     {
         return transform.position + positionOffset;
     }

     void OnMouseDown()
     {

         if (EventSystem.current.IsPointerOverGameObject())
         {
             return;
         }

         if (!buildMaster.CanBuild)
         {
             return;
         }

         if (turret != null)
         {
             Debug.Log("Can't build turret already placed here");
             return;
         }

         buildMaster.BuildTurretOn(this);
     }

     void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (!buildMaster.CanBuild)
        {
            return;
        }

        if (buildMaster.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneycolor;
        }
        
    
    }

     void OnMouseExit()
     {
         rend.material.color = startColor;
     }
}
