using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour {

    private BoyleController bigB;

	// Use this for initialization
	void Start () {
        bigB = FindObjectOfType<BoyleController>();
    }

    public void moveLeft()
    {
        bigB.btnLeft = true;
    }

    public void moveRight()
    {
        bigB.btnRight = true;
    }

    public void UnpressedMove()
    {
        bigB.btnRight = false;
        bigB.btnLeft = false;
    }
    public void UnpressedClimb()
    {
        bigB.btnUp = false;
        bigB.btnDown = false;
    }
    public void UnpressedJump()
    {
        bigB.btnJump = false;
    }

    public void climbUp()
    {
        bigB.btnUp = true;
    }

    public void climbDown()
    {
        bigB.btnDown = true;
    }

    public void jump()
    {
        bigB.btnJump = true;
    }
}
