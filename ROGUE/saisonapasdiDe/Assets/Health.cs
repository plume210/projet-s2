using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health = 100;
    public RectTransform healthBar;
    private PhotonView view;

    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(tag))
        {
            health -= 10;
            Debug.Log(health);
        }

        if (health <= 0 )
        {
            health = 0;
            Debug.Log("Dead!");
            PhotonNetwork.Destroy(gameObject);
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
