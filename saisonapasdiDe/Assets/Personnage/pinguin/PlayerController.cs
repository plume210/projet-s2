using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour

{
    public float rotate = 300.0f;
    void Update()
    {
        if (!isLocalPlayer) //code de déplacement + vérification pr voir si le joueur est un joueur local 
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;
            var y = Input.GetAxis("Jump");
            var angle = Input.GetAxisRaw("Mouse Y")*Time.deltaTime*rotate;
            var angley = Input.GetAxisRaw("Mouse X")*Time.deltaTime*rotate;
            transform.Translate(x, y, z);
        }
        
    }
    public override void OnStartLocalPlayer() //pour avoir la couleur des joueurs différents
        {
            GetComponent<MeshRenderer>().material.color = Color.blue; //a changer (1 joueur = 1 skins choisit au prealable)
        }
}
