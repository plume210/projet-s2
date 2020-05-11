using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Portail : MonoBehaviour
{
    private int health;

    public GameObject portail;

   
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        health = GetComponent<Health>().health;
        if (health == 0)
        {
            PhotonNetwork.Instantiate(portail.name, transform.position, Quaternion.identity);
            
        }
    }
}
