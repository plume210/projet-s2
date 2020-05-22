using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BOSSAPARITION : MonoBehaviour
{
    private int wave;
    public GameObject wavefinal;
    private Transform wavespawn;

    public Transform pos;

    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        wavespawn = GetComponent<enemiesspawn>().spawnwavtext;
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        wave = GetComponent<enemiesspawn>().Nbwaves;
        if (wave == 2 && other.tag == "Player" && GameObject.FindGameObjectsWithTag("enemies").Length == 0)
        {
            StartCoroutine(appartition());
        }
    }

    IEnumerator appartition()
    {
        GameObject ye = PhotonNetwork.Instantiate(wavefinal.name, wavespawn.position, wavespawn.rotation);
        yield return new WaitForSeconds(2);
        PhotonNetwork.Destroy(ye);
    }
}
