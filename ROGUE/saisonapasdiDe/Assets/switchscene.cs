﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Photon.Pun;
using Photon.Realtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class switchscene : MonoBehaviour
{
    public Transform hiver;
    public Transform ete;
    public Transform automne;
    public Transform Prindtemps;
    private Transform oui;
    
    private int waves;
    public int nbwaves;

    public void Start()
    {
        Transform[] listeendroite = new[] {hiver, automne, ete, Prindtemps};
        int i = new Random().Next(0,3);
    }

    private void Update()
    {
        waves = GetComponent<enemiesspawn>().Nbwaves;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (waves == nbwaves)
        {
            foreach (var VARIABLE in GameObject.FindGameObjectsWithTag("Player"))
            {
                VARIABLE.transform.position = oui.position;
            }
            
        }
    
    }
}