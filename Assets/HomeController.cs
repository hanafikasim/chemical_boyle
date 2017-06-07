using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Play()
    {
        PlayerPrefs.SetInt("boylePos", 1);
        PlayerPrefs.SetInt("camSpawn", 1);
        PlayerPrefs.SetInt("Level1_Finish", 1);
        PlayerPrefs.SetInt("Level2_Finish", 1);
        PlayerPrefs.SetInt("Level3_Finish", 1);
        PlayerPrefs.SetInt("Level4_Finish", 1);
        PlayerPrefs.SetInt("Level5_Finish", 0);
        PlayerPrefs.SetInt("Level6_Finish", 1);
        PlayerPrefs.SetInt("Level7_Finish", 0);
        PlayerPrefs.SetInt("Level8_Finish", 2);
        PlayerPrefs.SetInt("Level9_Finish", 2);
        SceneManager.LoadScene(14);
    }

    public void Exit()
    {
        //SceneManager.LoadScene(1);
        Debug.Log("Exit clicked!");
        Application.Quit();
    }

    public void Info()
    {
        Debug.Log("Info clicked!");
    }
}
