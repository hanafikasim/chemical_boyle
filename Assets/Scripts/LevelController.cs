using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public Transform spawnBoylePos;
    public Transform nextLevelPos;

    public int currentLevelID;
    public int nextLevelSceneID;

    private BoyleController bigB;

    // Use this for initialization
    void Start () {
        bigB = FindObjectOfType<BoyleController>();

        bigB.transform.position = spawnBoylePos.position;
    }
	
	// Update is called once per frame
	void Update () {

        switch (currentLevelID)
        {
            case 1:
                if (bigB.transform.position.y > nextLevelPos.position.y)
                {
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                break;

            case 2:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                break;

            case 3:
                if (bigB.transform.position.y < nextLevelPos.position.y)
                {
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                break;

            case 4:
                if (bigB.transform.position.y < nextLevelPos.position.y)
                {
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                break;

            case 5:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                break;

            case 6:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                break;
        }
    }
}
