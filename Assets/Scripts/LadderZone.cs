using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour {

    //private PlayerController thePlayer;
    private BoyleController bigB;

	// Use this for initialization
	void Start () {
        bigB = FindObjectOfType<BoyleController>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Dalton Boyle Prefab")
        {
            bigB.onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Dalton Boyle Prefab")
        {
            bigB.onLadder = false ;
        }
    }
}
