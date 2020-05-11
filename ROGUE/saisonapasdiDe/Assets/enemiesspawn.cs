using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Networking;
using Random = System.Random;


public class enemiesspawn : MonoBehaviourPunCallbacks
{
    public Transform enemiespawn1;
    public Transform enemiespawn2;
    public GameObject enemie1;
    public GameObject enemie2;
    public GameObject Boss;
    public GameObject wave1;
    public GameObject wave2;
    public GameObject wave3;
    public Transform spawnwavtext;
    private GameObject[] wavetext;
    

    private PhotonView _view;


    private (GameObject[], int)[] wavefinal;
    private GameObject[] enemiesliste;
    private int nbwaves =-1;

    public void Start()
    {
        
        enemiesliste = new []  {enemie1, enemie2};
        GameObject[] bosse = new[] {Boss};
        (GameObject[], int) waveboss = (bosse, 1);
        (GameObject[], int) wavesnb1 = (enemiesliste, 5);
        (GameObject[], int) wavesnb2 = (enemiesliste, 10);
        wavefinal = new []{wavesnb1, wavesnb2,waveboss};
        wavetext = new[] {wave1, wave2,wave3};
        
        _view = GetComponent<PhotonView>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameObject.FindGameObjectsWithTag("enemies").Length == 0)
        {
            nbwaves += 1;
            Debug.Log(nbwaves);
            StartCoroutine(waitsecond(5));
           
        }
    }

    

    IEnumerator waitsecond(int x)
    {
        (GameObject[] a, int b) = wavefinal[nbwaves];
        GameObject ye = PhotonNetwork.Instantiate(wavetext[nbwaves].name, spawnwavtext.transform.position,wavetext[nbwaves].transform.rotation);
        yield return new WaitForSeconds(5);
        PhotonNetwork.Destroy(ye);
        _view.RPC("enemispawn",RpcTarget.MasterClient,5, a);yield return new WaitForSeconds(x);
    }

   

    [PunRPC]
    void enemispawn(int enemiesnumer,GameObject[] name)
    {
        GameObject[] enemiestype = name;
        int i = new Random().Next(1, enemiesnumer);
        int g = 0;
        int e = 0;
        int u = 0;
        GameObject ENEMIETAMERELAPUTE = new GameObject();
        while (i > u)
        {
            int generation = new Random().Next(0, enemiestype.Length);
            int posx = new Random().Next(Convert.ToInt32(enemiespawn1.position.x),
                Convert.ToInt32(enemiespawn2.position.x)); // coord x aleatoitre
            int posy = new Random().Next(Convert.ToInt32(enemiespawn1.position.z),
                Convert.ToInt32(enemiespawn2.position.z)); // coord z aleatoire
            while (g == posx && posy == e)
            {
                posx = new Random().Next(Convert.ToInt32(enemiespawn1.position.x),
                    Convert.ToInt32(enemiespawn2.position.x));
                posy = new Random().Next(Convert.ToInt32(enemiespawn2.position.z),
                    Convert.ToInt32(enemiespawn2.position.z));
            }

            Vector3 pos = new Vector3(posx, enemiespawn2.position.y - 7, posy); // spawn du joueur
            ENEMIETAMERELAPUTE =
                PhotonNetwork.Instantiate(enemiestype[generation].name, pos, Quaternion.identity); // creer le joueur
           // Debug.Log(PhotonNetwork.CurrentRoom.Name);
           // Debug.Log("joueur" + PhotonNetwork.CurrentRoom.Players.Count);
            ENEMIETAMERELAPUTE.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
            //liste.GetComponent<Rigidbody>().useGravity = true;
            ENEMIETAMERELAPUTE.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            g = posx;
            e = posy;
            u += 1;
            i -= 1;
        }
    }
}