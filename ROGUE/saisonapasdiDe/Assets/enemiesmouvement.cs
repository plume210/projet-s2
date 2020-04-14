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
    private GameObject _player;
    private NavMeshAgent _agent;
    public float startshot;
    private float  timebtwshot;
    

    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        timebtwshot = startshot;
    }

    public void Update()
    {
        //_agent.SetDestination(_player.transform.position);
        _agent.destination = _player.transform.position;
        if (timebtwshot <= 0)

        {
            PhotonNetwork.Instantiate(tir.name, spawn.position, spawn.rotation, 0);
            timebtwshot = startshot;
        }
        else
        {
            timebtwshot -= Time.deltaTime;
        }
    }

   
}