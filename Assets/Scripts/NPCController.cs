﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    private Transform tikus;
    private BoyleController bigB;

    public Transform point1, point2, destination;
    public float speed;

    private float step;

    // Use this for initialization
    void Start () {
        tikus = gameObject.GetComponent<Transform>();
        destination = point2;
    }
	
	// Update is called once per frame
	void Update () {
        
        step = speed * Time.deltaTime;

        tikus.transform.position = Vector3.MoveTowards(tikus.transform.position, destination.position, step);

        if (tikus.transform.position == point1.transform.position)
        {
            destination = point2;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (tikus.transform.position == point2.transform.position)
        {
            destination = point1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Application.LoadLevel(0);
        }
    }
}
