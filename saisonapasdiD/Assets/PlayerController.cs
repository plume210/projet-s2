using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{ 
    void Update()
    {
        if (!isLocalPlayer) //code de déplacement + vérification pr voir si le joueur est un joueur local 
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        
        transform.Rotate(0,x,0);
        transform.Translate(0,0, z);
    }

    public override void OnStartLocalPlayer() //pour avoir la couleur des joueurs différents
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
