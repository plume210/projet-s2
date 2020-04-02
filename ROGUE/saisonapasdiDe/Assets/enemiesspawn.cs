﻿using System;
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

            int i = new Random().Next(1,4);
            int g = 0;
            int e = 0;
            int u =0;
            Debug.Log(i);
            while (i > u)
            {
                int posx = new Random().Next(Convert.ToInt32(enemiespawn1.position.x),Convert.ToInt32(enemiespawn2.position.x));
                int posy = new Random().Next(Convert.ToInt32(enemiespawn1.position.z),Convert.ToInt32(enemiespawn2.position.z));
                while (g == posx && posy == e)
                {
                    posx = new Random().Next(Convert.ToInt32(enemiespawn1.position.x),Convert.ToInt32(enemiespawn2.position.x));
                    posy = new Random().Next(Convert.ToInt32(enemiespawn1.position.z),Convert.ToInt32(enemiespawn2.position.z));
                    
                }
                Debug.Log(posx + "   " + posy);
                Vector3 pos = new Vector3(posx, enemiespawn2.position.y,posy);
                GameObject liste= PhotonNetwork.Instantiate(enemie.name, pos, Quaternion.identity, 0);
                liste.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                //liste.GetComponent<Rigidbody>().useGravity = true;
                liste.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                g = posx;
                e = posy;
                u+=1;
            }
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
