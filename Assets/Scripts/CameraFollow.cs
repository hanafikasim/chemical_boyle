using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;

    private Transform camSpawn;

    public Transform camSpawnPos;
    public Transform camSpawnPos_2;

    public float smoothTimeY;
    public float smoothTimeX;

    private BoyleController bigB;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    // Use this for initialization
    void Start () {
        camSpawn = gameObject.GetComponent<Transform>();
        bigB = FindObjectOfType<BoyleController>();
        if (PlayerPrefs.GetInt("camSpawn") == 1)

        {
            camSpawn.transform.position = camSpawnPos.transform.position;
        }
        if (PlayerPrefs.GetInt("camSpawn") == 2)
        {
            camSpawn.transform.position = camSpawnPos_2.transform.position;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, bigB.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, bigB.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                                             Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                                             Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
