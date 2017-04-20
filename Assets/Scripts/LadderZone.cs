using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour {

    private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "DummyPlayer")
        {
            thePlayer.onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "DummyPlayer")
        {
            thePlayer.onLadder = false ;
        }
    }
}
