using System;
using UnityEngine;
using UnityEngine.UI;

public class LIves : MonoBehaviour
{
    public Text LivesText;


     void Update()
     {
         LivesText.text = PlayerStats.Lives.ToString() + " LIVES ";
     }
}
