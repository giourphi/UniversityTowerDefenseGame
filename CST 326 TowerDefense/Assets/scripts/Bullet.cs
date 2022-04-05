using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public int damage = 5; 

  
    public void Seek(Transform _target)
    {
        target = _target;
    }

 
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);

    }

    void HitTarget()
    {
        GameObject effectInstance  = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance,2f);
        Destroy(gameObject);
        Damage(target);
       

    }


    void Damage(Transform enemy)
    {
        CharacterMovement c = enemy.GetComponent<CharacterMovement>();


        if (c != null)
        {
            c.TakeDamage(damage); 
        }
        
    }



}
