using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.ExceptionServices;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour

{
    public GameObject balled;
    public Transform bulletspawn;
    public float bulletspeed = 300.0f;
    public float speed = 300.0f;
    private PhotonView _view;
    private Animator anim;
   

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (_view.IsMine)
        {
            
            
            
            var x1 = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var z1 = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            var space = Input.GetAxis("Jump");
            
            anim.SetFloat("vertical",Input.GetAxis("Vertical"));
            anim.SetFloat("spacebar",space);
            
            transform.Rotate(0, 0, x1);
            transform.Translate(-z1, 0, 0);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                var bullet = PhotonNetwork.Instantiate(balled.name, bulletspawn.position, bulletspawn.rotation,0);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletspeed;
            }
        }
    }
}