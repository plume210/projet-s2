using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    public int health = 100;

    private Text txthealt;
    private Text bossText;
    
    // Start is called before the first frame update
    void Start()
    {
        txthealt = GameObject.Find("TxtHealth").GetComponent<Text>();
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Boullet")
        {
            health -= 10;
            txthealt.text = health.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
