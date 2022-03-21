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
    private int waypointIndex;
    private float hpstat = 10f;
    public float rayLength;
    public LayerMask layermask;
    public GameObject gamemanager;
    public GameObject enemy;
    // public GameObject enemies;
   
    // Start is called before the first frame update

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        //Instantiate(gameObject);
        gamemanager =  GameObject.FindGameObjectWithTag("gamemanager");
       enemy = GameObject.FindGameObjectWithTag("enemies");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position,
            speed * Time.deltaTime);

        Vector3 dir = Wpoints.waypoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            
        if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
         
            if (waypointIndex >= Wpoints.waypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }else
            {
                waypointIndex++;
            }
        }
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit, rayLength, layermask))
            {
                Debug.Log("raycasthit" );
                hpstat -=2;
            }
        }

    

       
        

    }

    public void FixedUpdate()
    {
        if (hpstat == 0)
        {
            Debug.Log("updating coinvalue");
            Destroy(this.enemy);
            GameManager.instance.CoinUpdate();
        }
    }

    public void resetHp()
    {
        hpstat = 10f;
        Debug.Log("reset hp");
    }
    
    


}
