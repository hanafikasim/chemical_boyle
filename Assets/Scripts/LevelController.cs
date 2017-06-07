using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public Transform spawnBoylePos;
    public Transform spawnBoylePos_2;
    public Transform spawnBoylePos_3;
    public Transform spawnBoylePos_4;
    public Transform nextLevelPos;
    public Transform nextLevelPos_2;
    public Transform nextLevelPos_3;
    public Transform nextLevelPos_4;

    public int currentLevelID;
    public int nextLevelSceneID;
    public int nextLevelSceneID_2;
    public int nextLevelSceneID_3;
    public int nextLevelSceneID_4;

    private BoyleController bigB;

    // Use this for initialization
    void Start () {
        bigB = FindObjectOfType<BoyleController>();
        if(PlayerPrefs.GetInt("boylePos") == 1)
        {
            PlayerPrefs.SetInt("boylePos", 1);
            bigB.transform.position = spawnBoylePos.position;
        }
        else if (PlayerPrefs.GetInt("boylePos") == 2)
        {
            bigB.transform.position = spawnBoylePos_2.position;
        }
        else if (PlayerPrefs.GetInt("boylePos") == 3)
        {
            bigB.transform.position = spawnBoylePos_3.position;
        }
    }
	
	// Update is called once per frame
	void Update () {

        switch (currentLevelID)
        {
            case 1:
                if (bigB.transform.position.y > nextLevelPos.position.y)
                {
                    PlayerPrefs.SetInt("camSpawn", 1);
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                if (bigB.transform.position.x < nextLevelPos_2.position.x)
                {
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID_2);
                }
                break;

            case 2:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    PlayerPrefs.SetInt("camSpawn", 1);
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                if (bigB.transform.position.y < nextLevelPos_2.position.y)
                {
                    PlayerPrefs.SetInt("camSpawn", 2);
                    PlayerPrefs.SetInt("boylePos", 3);
                    SceneManager.LoadScene(nextLevelSceneID_2);
                }
                break;

            case 3:
                if (bigB.transform.position.y < nextLevelPos.position.y)
                {
                    PlayerPrefs.SetInt("camSpawn", 1);
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                if (bigB.transform.position.x < nextLevelPos_2.position.x)
                {
                    PlayerPrefs.SetInt("camSpawn", 2);
                    PlayerPrefs.SetInt("boylePos", 2);
                    SceneManager.LoadScene(nextLevelSceneID_2);
                }
                break;

            case 4:
                if (bigB.transform.position.y < nextLevelPos.position.y)
                {
                    PlayerPrefs.SetInt("camSpawn", 1);
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                if (bigB.transform.position.x < nextLevelPos_2.position.x)
                {
                    PlayerPrefs.SetInt("boylePos", 2);
                    SceneManager.LoadScene(nextLevelSceneID_2);
                }
                if (bigB.transform.position.x > nextLevelPos_3.position.x)
                {
                    PlayerPrefs.SetInt("camSpawn", 1);
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID_3);
                }
                if (bigB.transform.position.y > nextLevelPos_4.position.y)
                {
                    PlayerPrefs.SetInt("camSpawn", 2);
                    PlayerPrefs.SetInt("boylePos", 2);
                    SceneManager.LoadScene(nextLevelSceneID_4);
                }
                break;

            case 5:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    PlayerPrefs.SetInt("camSpawn", 2);
                    PlayerPrefs.SetInt("boylePos", 2);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                break;

            case 6:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    PlayerPrefs.SetInt("camSpawn", 1);
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                if (bigB.transform.position.x < nextLevelPos_2.position.x)
                {
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID_2);
                }
                if (bigB.transform.position.y > nextLevelPos_3.position.y)
                {
                    PlayerPrefs.SetInt("camSpawn", 2);
                    PlayerPrefs.SetInt("boylePos", 3);
                    SceneManager.LoadScene(nextLevelSceneID_3);
                }
                break;

            case 7:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    PlayerPrefs.SetInt("camSpawn", 2);
                    PlayerPrefs.SetInt("boylePos", 2);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                break;

             case 8:
                if (bigB.transform.position.y > nextLevelPos.position.y)
                {
                    PlayerPrefs.SetInt("camSpawn", 1);
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                if (bigB.transform.position.x < nextLevelPos_2.position.x)
                {
                    PlayerPrefs.SetInt("camSpawn", 2);
                    PlayerPrefs.SetInt("boylePos", 3);
                    SceneManager.LoadScene(nextLevelSceneID_2);
                }
                break;

            case 9:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    PlayerPrefs.SetInt("camSpawn", 1);
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                if (bigB.transform.position.y < nextLevelPos_2.position.y)
                {
                    PlayerPrefs.SetInt("camSpawn", 2);
                    PlayerPrefs.SetInt("boylePos", 2);
                    SceneManager.LoadScene(nextLevelSceneID_2);
                }
                break;

            case 10:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    Destroy(GameObject.FindGameObjectWithTag("LevelsBGM"));
                    SceneManager.LoadScene(nextLevelSceneID);
                    
                }
                break;

            case 11:
                if (bigB.transform.position.x < nextLevelPos.position.x)
                {
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                if (bigB.transform.position.x > nextLevelPos_2.position.x)
                {
                    PlayerPrefs.SetInt("boylePos", 2);
                    SceneManager.LoadScene(nextLevelSceneID_2);
                }
                break;

            case 12:
                if (bigB.transform.position.x < nextLevelPos.position.x)
                {
                    PlayerPrefs.SetInt("boylePos", 1);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                if (bigB.transform.position.x > nextLevelPos_2.position.x)
                {
                    PlayerPrefs.SetInt("boylePos", 2);
                    SceneManager.LoadScene(nextLevelSceneID_2);
                }
                break;

            case 13:
                if (bigB.transform.position.x > nextLevelPos.position.x)
                {
                    PlayerPrefs.SetInt("boylePos", 2);
                    SceneManager.LoadScene(nextLevelSceneID);
                }
                break;
        }
    }
}
