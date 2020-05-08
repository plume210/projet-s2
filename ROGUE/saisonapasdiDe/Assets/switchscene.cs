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
  public void OnTriggerEnter(Collider other)
  {
    SceneManager.LoadScene("mapprintemps2");
    foreach (var VARIABLE in GameObject.FindGameObjectsWithTag("Player"))
    {
      PhotonNetwork.Disconnect();
    }
  }
}