using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tirenemideplacement : MonoBehaviour
{
    public float speed;
    private Vector3 target;
    private GameObject[] player;
    public void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        target = player[sort2(player)].transform.position;

    }
    public int sort2(GameObject[] joueurs)                                                                     
    {                                                                                                          
        float distance = Vector3.Distance(joueurs[0].transform.position, transform.position);                  
        int j = 0;                                                                                             
        for (int i = 0; i < joueurs.Length; i++)                                                               
        {                                                                                                      
            float distance2 = Vector3.Distance(joueurs[i].transform.position, transform.position);             
            if (distance2<distance)                                                                            
            {                                                                                                  
                distance = distance2;                                                                          
                j = i;                                                                                         
            }
        }
        return j;
    }                                                                                                          

  

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            DestroyProjectile();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        
            DestroyProjectile();
        
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}