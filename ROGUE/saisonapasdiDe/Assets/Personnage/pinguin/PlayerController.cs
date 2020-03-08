using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour

{
    public GameObject balled;
    public Transform bulletspawn;
    public float bulletspeed = 300.0f;
    public float speed = 300.0f;
    public float mousesensitivity = 2f;
    

    void Update()
    {
        if (!isLocalPlayer) //code de déplacement + vérification pr voir si le joueur est un joueur local 
        {
            return;
        }
        
        var x1 = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z1 = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var y1 = Input.GetAxis("Jump");
        //var angle = Input.GetAxisRaw("Mouse Y")*Time.deltaTime*speed;
        //var angle2 = Input.GetAxisRaw("Mouse X")*Time.deltaTime*speed;
        transform.Translate(z1, 0, 0);
        transform.Rotate(0,x1, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cmdFire();
        }
        
        void cmdFire()
        {
            // instantiate = creer a une certaine position
            var bullet = (GameObject) Instantiate(balled, bulletspawn.position,bulletspawn.rotation);
            // ajout de la velocite a la balle
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletspeed;
            // f = temps (2seconde)
            // Destroy(bullet,2.0f);
        }
        
    }
    public override void OnStartLocalPlayer() //pour avoir la couleur des joueurs différents
    {
        GetComponent<MeshRenderer>().material.color = Color.blue; //a changer (1 joueur = 1 skins choisit au prealable)
    }
}