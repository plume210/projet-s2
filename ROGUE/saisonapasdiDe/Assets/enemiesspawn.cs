﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Networking;
using Random = System.Random;

public class enemiesspawn : MonoBehaviour
{
    public Transform enemiespawn1;
    public Transform enemiespawn2;
    public GameObject enemie;
    private string player = "Player";
    public GameObject type;
    private PhotonView _view;
    

    // Start is called before the first frame update
    public void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        _view = GetComponent<PhotonView>();
        
        
    }

    public  void OnTriggerEnter(Collider other)
    {
        if (player == "Player")
        {
            if (other.tag == player)
            {
                _view.RPC("spawnenemie", RpcTarget.MasterClient);
                
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        GameObject[]
            enemiesliste = GameObject.FindGameObjectsWithTag("enemies"); // recupere le nombre denemies dans la map
        if (enemiesliste.Length >= 4)
        {
            player = "Respawn";
        }
    } // Update is called once per frame
    [PunRPC]
    void spawnenemie()
    {
        GameObject[] enemiestype = new GameObject[2]; // pour selectionner le type denemies
        enemiestype[1] = enemie;
        enemiestype[0] = type;
        int i = new Random().Next(1, 4);
        int g = 0;
        int e = 0;
        int u = 0;
        while (i > u)
        {
            int generation = new Random().Next(enemiestype.Length);
            int posx = new Random().Next(Convert.ToInt32(enemiespawn1.position.x),
                Convert.ToInt32(enemiespawn2.position.x)); // coord x aleatoitre
            int posy = new Random().Next(Convert.ToInt32(enemiespawn1.position.z),
                Convert.ToInt32(enemiespawn2.position.z)); // coord z aleatoire
            while (g == posx && posy == e)
            {
                posx = new Random().Next(Convert.ToInt32(enemiespawn1.position.x),
                    Convert.ToInt32(enemiespawn2.position.x));
                posy = new Random().Next(Convert.ToInt32(enemiespawn2.position.z),
                    Convert.ToInt32(enemiespawn2.position.z));

            }

            Vector3 pos = new Vector3(posx, enemiespawn2.position.y, posy); // spawn du joueur
            GameObject liste =
                PhotonNetwork.Instantiate(enemiestype[generation].name, pos, Quaternion.identity); // creer le joueur
            Debug.Log(PhotonNetwork.CurrentRoom.Name);
            Debug.Log("joueur" + PhotonNetwork.CurrentRoom.Players.Count);
            liste.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
            //liste.GetComponent<Rigidbody>().useGravity = true;
            liste.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            g = posx;
            e = posy;
            u += 1;
        }
    }
}