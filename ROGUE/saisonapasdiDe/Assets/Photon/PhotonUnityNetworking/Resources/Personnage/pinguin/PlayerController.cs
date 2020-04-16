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
    private Animator anim;

    public GameObject balled;
    public Transform bulletspawn;
    public float bulletspeed = 300.0f;
    public float speed = 300.0f;
    private PhotonView _view;
    private Camera _camera;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        _camera = GetComponentInChildren<Camera>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_view.IsMine)
        {
            //prendre les imputs
            var x1 = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var z1 = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            //anim
            anim.SetFloat("vertical", z1);
      

            //deplacement
            transform.Rotate(0, x1, 0);
            transform.Translate(0, 0, z1);

            //tir
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var bullet = PhotonNetwork.Instantiate(balled.name, bulletspawn.position, bulletspawn.rotation,0);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletspeed;
            }
        }
    }
}