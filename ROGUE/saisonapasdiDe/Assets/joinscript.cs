
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;


public class joinscript : MonoBehaviourPunCallbacks
{
    public Transform spawn;
    public GameObject player;
    public Camera camera;
    public Transform spawn2;
    private GameObject[] nbplayers;
   
  


    // Start is called before the first frame update
    void Start()
    {
       
        
       
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("connected to " + PhotonNetwork.CloudRegion);
        
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("connected to " + PhotonNetwork.CurrentLobby);
    }

    public override void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        //a changer pour le multi ou le solo
        PhotonNetwork.JoinOrCreateRoom("essai", roomOptions, TypedLobby.Default);
        Debug.Log("Creating room: " + PhotonNetwork.CurrentRoom);
       
        Debug.Log("Joined " + PhotonNetwork.CurrentRoom);
    }

    public override void OnJoinedRoom()
    {
       
        StartCoroutine(Spawnplayer());
        Debug.Log(PhotonNetwork.CurrentRoom.Players.Count);
        Debug.Log("Dématérialisation !!!!!!");
       
    }
    

    IEnumerator Spawnplayer()
    {
        int random = new Random().Next(2);
        Vector3 sp;
        sp = new Vector3(spawn.transform.position.x +
                         spawn.transform.position.z,
            spawn.transform.position.y);
        GameObject Myplayer;
        if (random == 1)
        {
            Myplayer = PhotonNetwork.Instantiate(player.name, spawn.position, Quaternion.identity, 0);
        }
        else
        {
            Myplayer = PhotonNetwork.Instantiate(player.name, spawn2.position, Quaternion.identity, 0);
        }

        camera.GetComponent<CameraSmooth>().target = Myplayer.transform;
        Myplayer.transform.Rotate(-90, 0, 0);
        yield return new WaitForSeconds(0.1f);
        //Myplayer.AddComponent<Rigidbody>();
        Myplayer.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        Myplayer.GetComponent<Rigidbody>().useGravity = true;
        Myplayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
     
}
