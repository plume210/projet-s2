using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour

{
    public float speed = 300.0f;
    void Update()
    {
        if (!isLocalPlayer) //code de déplacement + vérification pr voir si le joueur est un joueur local 
        {
            var x1 = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z1 = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;
            var y1 = Input.GetAxis("Jump");
            var angle = Input.GetAxisRaw("Mouse Y")*Time.deltaTime*speed;
            var angley = Input.GetAxisRaw("Mouse X")*Time.deltaTime*speed;
            transform.Translate(x1, y1, z1);
            var rotate2 = Camera.current.ScreenToWorldPoint(Input.mousePosition);
            transform.Rotate(rotate2, Input.mousePosition.x);
        }
        
    }
    public override void OnStartLocalPlayer() //pour avoir la couleur des joueurs différents
        {
            GetComponent<MeshRenderer>().material.color = Color.blue; //a changer (1 joueur = 1 skins choisit au prealable)
        }
}
