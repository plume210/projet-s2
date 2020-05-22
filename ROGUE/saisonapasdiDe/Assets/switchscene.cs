using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Photon.Pun;
using Photon.Realtime;

using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class switchscene : MonoBehaviour
{
    public Transform hiver;
    public Transform portail;
   
    private int i;
    public GameObject vortex;
    
    private int waves;
    public int nbwaves;

    public void Start()
    {
      
    }

    private void Update()
    {
        waves = GetComponent<enemiesspawn>().Nbwaves;
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (waves == nbwaves-1)
        {
            PhotonNetwork.Instantiate(vortex.name, portail.position, portail.rotation);
        }
        if (waves == nbwaves)
        {
            foreach (var VARIABLE in GameObject.FindGameObjectsWithTag("Player"))
            {
                VARIABLE.transform.position = hiver.position;
            }
            
        }
    
    }
}