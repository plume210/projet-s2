using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class bosstir : MonoBehaviour
{
    public Transform tirspawns;

    public GameObject objet;

    public int bulletspeed = 100;
    private float  timebtwshot;
    public float startshot;

   
    // Start is called before the first frame update
    void Start()
    {
        timebtwshot = startshot;
    }

    // Update is called once per frame
    void Update()
    {
        tirspawns.transform.RotateAround(transform.position,transform.up,1);
        if (timebtwshot <= 0)
        { 
            GameObject bullet = PhotonNetwork.Instantiate(objet.name, tirspawns.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = tirspawns.forward * bulletspeed;
            timebtwshot = startshot;
        }
        else
        {
            timebtwshot -= Time.deltaTime;
        }

    }

   
} 
