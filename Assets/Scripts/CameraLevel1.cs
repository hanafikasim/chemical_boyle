using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevel1 : MonoBehaviour {

    public Transform boyle;
    public Camera cam;

    private float horizontalOffset, depthOffset;

	// Use this for initialization
	void Start () {
        horizontalOffset = 0;
        depthOffset = -10;
	}
	
	// Update is called once per frame
	void Update () {
        cam.transform.position = new Vector3(horizontalOffset, boyle.position.y, depthOffset); 
	}
}
