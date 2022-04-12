using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;
    public GameObject gameOverUI;
    void Update()
    {
        if (gameEnded)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        
            if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        
        
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);

    }
}
