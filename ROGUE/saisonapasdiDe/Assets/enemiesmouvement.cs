using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class enemiesmouvement : MonoBehaviour
{
    public Transform spawn;
    public GameObject tir;
    private GameObject[] _player;
    private NavMeshAgent _agent;
    public float startshot;
    private float  timebtwshot;
    public float speed;
    private Vector3 target;
    private Transform joueur;
    
    

    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        timebtwshot = startshot;
       
    }

    

    public void sort(GameObject[] bruh)
    {
        int i = 0;
        
        while (i<bruh.Length-2)
        {
            float distance = Vector3.Distance(bruh[i].transform.position, transform.position);
            float distance2 = Vector3.Distance(bruh[i+1].transform.position, transform.position); 
            if (distance>distance2)
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
        _player = GameObject.FindGameObjectsWithTag("Player");
        sort(_player);   
        //_agent.SetDestination(_player.transform.position);
        _agent.destination = _player[0].transform.position;
        if (timebtwshot <= 0)

        { 
            GameObject bullet = Instantiate(tir, spawn.position, Quaternion.identity) as GameObject;
            timebtwshot = startshot;
        }
        else
        {
            timebtwshot -= Time.deltaTime;
        }
    }
}