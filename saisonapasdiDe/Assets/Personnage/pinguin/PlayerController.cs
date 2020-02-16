﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour

{
    public float speed = 300.0f;
    public float mousesensitivity = 2f;
    void Update()
    {
        if (isLocalPlayer) //code de déplacement + vérification pr voir si le joueur est un joueur local 
        {
            var x1 = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z1 = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;
            var y1 = Input.GetAxis("Jump");
            var angle = Input.GetAxisRaw("Mouse X")*Time.deltaTime*speed;
            transform.Translate(z1, y1, x1);
            float mouseposition = Input.GetAxis("Mouse X") * mousesensitivity;
            transform.Rotate(0, angle,0 );
        }
        
    }
    public override void OnStartLocalPlayer() //pour avoir la couleur des joueurs différents
        {
            GetComponent<MeshRenderer>().material.color = Color.blue; //a changer (1 joueur = 1 skins choisit au prealable)
        }
}
