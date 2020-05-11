using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class apparitiongemme : MonoBehaviour
{
    public GameObject gemme;

    public int nbwaves = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject oui = new GameObject();
        GameObject[] enemiesliste = GameObject.FindGameObjectsWithTag("enemies");
        if (enemiesliste.Length == 0)
        {
            nbwaves += 1; 
            oui = PhotonNetwork.Instantiate(gemme.name, transform.position, transform.rotation);
        }
        else
        {
            PhotonNetwork.Destroy(oui);
        }
        
    }
}
