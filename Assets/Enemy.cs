using System.Net.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public GameObject skycraper;
    private float skycraperWidth;
    private bool moveRight = true;
    private SpriteRenderer r;

    void Start() 
    {
        skycraperWidth = skycraper.GetComponent<BoxCollider2D>().size.x;
        r = GetComponent<SpriteRenderer>();
    }
    void Update()
    {   
        if (moveRight)
        {
            transform.position += Vector3.right * Time.deltaTime * speed ;
        }
        else 
        {
            transform.position += Vector3.left * Time.deltaTime * speed ;
        }

        if (transform.position.x > skycraper.transform.position.x + skycraperWidth)
        {
            moveRight = false;
            r.flipX = true;
        }
        if (transform.position.x < skycraper.transform.position.x - skycraperWidth)
        {
            moveRight = true;
            r.flipX = false;
        }

    }
}
