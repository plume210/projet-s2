using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;

using Photon.Realtime;
using UnityEngine;
using Random = System.Random;

public class enemiesspawn : MonoBehaviour
{
    public Transform enemiespawn1;
    public Transform enemiespawn2;
    public GameObject enemie;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {

        
        if (other.tag == "Player")
        {

            int i = new Random().Next(15);
            GameObject[] liste = new GameObject[i];
            int u = 0;
            while (i > u)
            {
                int random = new Random().Next(2);
                if (random == 1)
                {
                    liste[u] = PhotonNetwork.Instantiate(enemie.name, enemiespawn2.position, Quaternion.identity, 2);

                }
                else
                { 
                    liste[u] = PhotonNetwork.Instantiate(enemie.name, enemiespawn1.position, Quaternion.identity, 2);
                }

                liste[u].AddComponent<Rigidbody>();
                liste[u].AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                u+=1;
            }

            other.tag = "untagged";
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
