using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Bulle : MonoBehaviour
{
    public string[] Phrases;
    public bool Defil = true;
    public float speed = 0.05f;

    private TextMesh txt;
    private string txtDepart;
    void Start()
    {
        txt = transform.GetChild(0).GetComponent<TextMesh>();
        txtDepart = Phrases[0].Replace("|", System.Environment.NewLine);

        if (Defil)
        {
            StartCoroutine(AfficheText());
        }
        else
        {
            txt.text = txtDepart;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            txtDepart = Phrases[1].Replace("|", System.Environment.NewLine);
            StartCoroutine(AfficheText());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            txtDepart = Phrases[2].Replace("|", System.Environment.NewLine);
            StartCoroutine(AfficheText());
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            txtDepart = Phrases[3].Replace("|", System.Environment.NewLine);
            StartCoroutine(AfficheText());
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            txtDepart = Phrases[4].Replace("|", System.Environment.NewLine);
            StartCoroutine(AfficheText());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    IEnumerator AfficheText()
    {
        string te = txtDepart;
        int l = te.Length;
        for (int i = 0; i <= l; i++)
        {
            yield return new WaitForSeconds(speed);
            txt.text = te.Substring(0, i);
        }
    }
}
