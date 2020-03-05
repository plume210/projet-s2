using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour

{
    public GameObject balled;
    public Transform bulletspawn;
    public float speed = 300.0f;
    public float mousesensitivity = 2f;
    void Update()
    {
        if (!isLocalPlayer) //code de déplacement + vérification pr voir si le joueur est un joueur local 
        {
            var x1 = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z1 = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;
            var y1 = Input.GetAxis("Jump");
            var angle = Input.GetAxisRaw("Mouse Y")*Time.deltaTime*speed;
            var angle2 = Input.GetAxisRaw("Mouse X")*Time.deltaTime*speed;
            transform.Translate(z1, 0, x1);
            var positiondujoueur = new Vector3(x1,y1);
            transform.Rotate(positiondujoueur, angle2);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

        void Fire()
        {
            // instantiate = creer a une certaine position
            var bullet = (GameObject) Instantiate(balled, bulletspawn.position, bulletspawn.rotation);
            // ajout de la velocite a la balle
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
            // f = temps (2seconde)
           // Destroy(bullet,2.0f);
        }
        
    }
    public override void OnStartLocalPlayer() //pour avoir la couleur des joueurs différents
        {
            GetComponent<MeshRenderer>().material.color = Color.blue; //a changer (1 joueur = 1 skins choisit au prealable)
        }
}
