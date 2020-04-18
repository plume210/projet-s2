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
        sort(player);
        target = player[0].transform.position;

    }
    public double distance(GameObject objet)
    {
        return Math.Sqrt(Math.Pow(objet.transform.position.x + transform.position.x, 2) + 
                         Math.Pow(objet.transform.position.y + transform.position.x, 2) +
                         Math.Pow(objet.transform.position.z + transform.position.z, 2));
    }

    public void sort(GameObject[] bruh)
    {
        int i = 0;
        
        while (i<bruh.Length-2)
        {
            
            if (distance(bruh[i]) > distance(bruh[i + 1]))
            {
                (bruh[i], bruh[i + 1]) = (bruh[i + 1], bruh[i]);
                if (i==0)
                {
                    i += 1;
                }
                else
                {
                    i = i - 1;    
                }
                
            }
            else
            {
                i += 1;
            }
        }
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
        if (other.gameObject.tag == "Player")
        {
            DestroyProjectile();
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}