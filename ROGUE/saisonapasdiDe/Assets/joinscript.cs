
using System;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class joinscript : MonoBehaviourPunCallbacks
{
    public Transform spawn;
    public GameObject player;
    public Camera camera;
    
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
        GameObject Myplayer = PhotonNetwork.Instantiate(player.name,spawn.position, Quaternion.identity, 0);
        camera.GetComponent<CameraSmooth>().target = Myplayer.transform;
        yield return new WaitForSeconds(5);
        Myplayer.AddComponent<Rigidbody>();
        Myplayer.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
}
