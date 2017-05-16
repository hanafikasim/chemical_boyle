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
        //PlayerPrefs.SetInt("PreviousLevel", 0);
        SceneManager.LoadScene(1);
    }
}
