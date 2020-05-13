using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Photon.Pun;
using Photon.Realtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchscene : MonoBehaviour
{
  public Transform oui;
  
  
  public void OnTriggerEnter(Collider other)
  {
    foreach (var VARIABLE in GameObject.FindGameObjectsWithTag("Player"))
    {
      VARIABLE.transform.position = oui.position;
    }
    
  }
}