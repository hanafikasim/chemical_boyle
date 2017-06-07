using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartAdventure()
    {
        SceneManager.LoadScene(1); 
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
