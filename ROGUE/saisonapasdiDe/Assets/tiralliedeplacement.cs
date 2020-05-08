using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class tiralliedeplacement : MonoBehaviour
{
    public float speed;
    private Vector3[] target = new Vector3[0];
    private GameObject[] player;

    public void Start()
    {
       
    }

    public void Update()
    {
        player = GameObject.FindGameObjectsWithTag("enemies");
        for (int i = 0; i < player.Length; i++)
        {
            target.Append(player[i].transform.position);
            bool z = false;
            int j = target.Length-1;
            while (!z && j-1>0)
            {
                if (Math.Sqrt((Math.Pow(target[j].x, 2)) + (Math.Pow(target[j].y, 2)) + (Math.Pow(target[j].z, 2))) <
                    Math.Sqrt((Math.Pow(target[j - 1].x, 2)) + (Math.Pow(target[j - 1].y, 2)) +
                              (Math.Pow(target[j - 1].z, 2))))
                {
                    (target[j], target[j - 1]) = (target[j - 1], target[j]);
                    j = j - 1;
                }
            }
        }
        if (target.Length > 0)
        {
            Vector3 pos = target[0];
            
            if (transform.position == pos)
            {
                DestroyProjectile();
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemies")
        {
            DestroyProjectile();
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    
}
