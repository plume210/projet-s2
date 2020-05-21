﻿using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health = 100;
    public RectTransform healthBar;
    private PhotonView view;
    public int dmg;

    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            health -= dmg;
            Debug.Log(health);
            PhotonNetwork.Destroy(other.gameObject);
        }

        if (health <= 0 )
        {
            health = 0;
            Debug.Log("Dead!");
            PhotonNetwork.Destroy(gameObject);
            SceneManager.LoadScene("Fin/GameOver");
        }
    }

   
    public void Update()
    {
        view.RPC("MajVie",RpcTarget.All);
    }

    [PunRPC]
    void MajVie()
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
    
}
