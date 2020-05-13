using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class tircollision : MonoBehaviour
{
    public string asp;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == asp)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
