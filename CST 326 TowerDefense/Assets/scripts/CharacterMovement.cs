using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement instance;
    public float speed;
    private Waypoints Wpoints;
    private int waypointIndex =0;
    private float hpstat = 10f;
    public GameObject gamemanager;
    public GameObject enemy;
    [Header("unity stuff")] 
    public Image healthbar;
    private Transform target;
    public float startHealth = 20;
    private float health;
    //public float val = 2f;
    // public GameObject enemies;
   
    // Start is called before the first frame update

    public void Awake()
    {
      // instance = this;
    }

    void Start()
    {
        
       enemy = GameObject.FindGameObjectWithTag("Enemy");
       health = startHealth;

       target = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWavepoint();
        }

     
    }


    public void TakeDamage( int amount)
    {
        health -= amount;
        
        healthbar.fillAmount = health/startHealth;

        if (health <= 0)
        {
            PlayerStats.Money += 5;
            Destroy(enemy);
            
        }


    }
    void GetNextWavepoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
           Destroy(gameObject);
           return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
    


}
