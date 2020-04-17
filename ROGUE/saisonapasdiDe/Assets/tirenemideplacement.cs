using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tirenemideplacement : MonoBehaviour
{
    public float speed;
    private Vector3 target;
    private Transform player;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.transform.position;
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            DestroyProjectile();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyProjectile();
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}