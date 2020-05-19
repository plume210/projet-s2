using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class collider : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "AllyBullet")
        {
            PhotonNetwork.Destroy(other.gameObject);
        }
    }
}
