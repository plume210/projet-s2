using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    
    public int speed = 3; // vitesse du projectile en seconde.
    public int damage = 1;
    public GameObject projectile;// point de dégat
    
    public bool isEnemyShot = false; //projetcile enemie ou alors ami
// Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20); // 20 seconde.
    }

    private void Update()
    {
        var i = Input.GetAxis("Fire1");
    }

    // Update is called once per fram
}