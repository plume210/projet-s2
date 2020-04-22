﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class enemiesmouvement : MonoBehaviour
{
    public Transform spawn;
    public GameObject tir;
    private GameObject[] _player;
    private NavMeshAgent _agent;
    public float startshot;
    private float  timebtwshot;
    private PhotonView view;
    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        timebtwshot = startshot; 
        view = GetComponent<PhotonView>();
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
      view.RPC("deplacementandtir", RpcTarget.All);
    }

    [PunRPC]
    void deplacementandtir()
    {
      
        _player = GameObject.FindGameObjectsWithTag("Player");
        if (_player.Length == 0)
        {
            Application.Quit();
        }
      
        

        _agent.SetDestination(_player[sort2(_player)].transform.position);
       
        
        if (timebtwshot <= 0)

        { 
            GameObject bullet = Instantiate(tir, spawn.position, Quaternion.identity) as GameObject;
            bullet.AddComponent<Rigidbody>();
            timebtwshot = startshot;
        }
        else
        {
            timebtwshot -= Time.deltaTime;
        }
    }
}