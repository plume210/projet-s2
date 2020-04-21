
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

using Random = System.Random;


public class joinscript : MonoBehaviourPunCallbacks
{
    public Transform spawn;
    public GameObject player;
    public Camera camera;
    public Transform spawn2;
    private  GameObject[] nbplayers;
    


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
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("Room", roomOptions, TypedLobby.Default);
        Debug.Log("Creating room: " + PhotonNetwork.CurrentRoom);
        //PhotonNetwork.JoinRoom("Room");
        Debug.Log("Joined " + PhotonNetwork.CurrentRoom);
    }

    public override void OnJoinedRoom()
    {

        StartCoroutine(Spawnplayer());
       
        
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
          Myplayer = PhotonNetwork.Instantiate(player.name,spawn.position, Quaternion.identity, 0);  
        }
        else
        {
             Myplayer = PhotonNetwork.Instantiate(player.name,spawn2.position, Quaternion.identity, 0);
        }
       
        camera.GetComponent<CameraSmooth>().target = Myplayer.transform;
        Myplayer.transform.Rotate(-90,0,0);
        yield return new WaitForSeconds(5);
        //Myplayer.AddComponent<Rigidbody>();
        Myplayer.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        Myplayer.GetComponent<Rigidbody>().useGravity = true;
        Myplayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        
       

    }

   // public void Update()
   // {
    //    nbplayers = GameObject.FindGameObjectsWithTag("Player");
    //    if (Time.realtimeSinceStartup > 30f && nbplayers.Length == 0)
    //    {
   //         Application.Quit(); 
           
   //     }
  //  }

    private void ApplicationOnquitting()
    {
        Debug.Log("arret");
    }
}
