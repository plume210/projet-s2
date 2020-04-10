using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;

using Photon.Realtime;
using UnityEngine;
using Random = System.Random;

public class enemiesspawn : MonoBehaviour
{
    public Transform enemiespawn1;
    public Transform enemiespawn2;
    public GameObject enemie;

    public GameObject type;
    // Start is called before the first frame update
    public void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {

        
        if (other.tag == "Player")
        {
            GameObject[] enemies = new GameObject[2];
            enemies[1] = enemie;
            enemies[0] = type;
            int i = new Random().Next(1,4);
            int g = 0;
            int e = 0;
            int u =0;
            Debug.Log(i);
            while ( 1> u)
            {
                int generation = new Random().Next(enemies.Length);
                int posx = new Random().Next(Convert.ToInt32(enemiespawn1.position.x),Convert.ToInt32(enemiespawn2.position.x));
                int posy = new Random().Next(Convert.ToInt32(enemiespawn1.position.z),Convert.ToInt32(enemiespawn2.position.z));
                while (g == posx && posy == e)
                {
                    posx = new Random().Next(Convert.ToInt32(enemiespawn1.position.x),Convert.ToInt32(enemiespawn2.position.x));
                    posy = new Random().Next(Convert.ToInt32(enemiespawn1.position.z),Convert.ToInt32(enemiespawn2.position.z));
                    
                }
                Debug.Log(posx + "   " + posy);
                Vector3 pos = new Vector3(posx, enemiespawn2.position.y,posy);
                GameObject liste= PhotonNetwork.Instantiate(enemies[generation].name, pos, Quaternion.identity, 0);
                liste.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                //liste.GetComponent<Rigidbody>().useGravity = true;
                liste.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                g = posx;
                e = posy;
                u+=1;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
