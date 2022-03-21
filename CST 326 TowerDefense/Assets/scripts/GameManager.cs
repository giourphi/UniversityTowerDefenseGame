using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float coinCounter =0f;
    //public float hpstat = 10f;
    [Header("Score UI")] 
    public GameObject coinText;
    TextMeshPro text;

    public void Awake()
    {
        instance = this;
    }

    public void CoinUpdate()
   {
       
       coinCounter+= 1f;
       coinText.GetComponent<TextMeshProUGUI>().text = coinCounter.ToString();
       CharacterMovement.instance.resetHp();

   }
}
