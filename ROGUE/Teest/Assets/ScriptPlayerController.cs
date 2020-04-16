using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPlayerController : MonoBehaviour
{
    public Animator anim;
    public float speed = 300.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x1 = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z1 = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        transform.Rotate(0, 0, x1);
        transform.Translate(-z1, 0, 0);
    }
}
