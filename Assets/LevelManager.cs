using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int LevelId;

    public GameObject Elements, Compounds, Obstacles;

    // Use this for initialization
    void Start()
    {
        switch (LevelId)
        {
            case 1:
                if (PlayerPrefs.GetInt("Level1_Finish") == 0)
                {
                    Elements.SetActive(false);
                    Compounds.SetActive(false);
                    Obstacles.SetActive(false);
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("Level2_Finish") == 0)
                {
                    Elements.SetActive(false);
                    Compounds.SetActive(false);
                    Obstacles.SetActive(false);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("Level3_Finish") == 0)
                {
                    Elements.SetActive(false);
                    Compounds.SetActive(false);
                    Obstacles.SetActive(false);
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("Level4_Finish") == 0)
                {
                    Elements.SetActive(false);
                    Compounds.SetActive(false);
                    Obstacles.SetActive(false);
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt("Level5_Finish") == 0)
                {
                    Elements.SetActive(false);
                    Compounds.SetActive(false);
                    Obstacles.SetActive(false);
                }
                break;
            case 6:
                if (PlayerPrefs.GetInt("Level6_Finish") == 0)
                {
                    Elements.SetActive(false);
                    Compounds.SetActive(false);
                    Obstacles.SetActive(false);
                }
                break;
            case 7:
                if (PlayerPrefs.GetInt("Level7_Finish") == 0)
                {
                    Elements.SetActive(false);
                    Compounds.SetActive(false);
                    Obstacles.SetActive(false);
                }
                break;
            case 8:
                if (PlayerPrefs.GetInt("Level8_Finish") == 0)
                {
                    Elements.SetActive(false);
                    Compounds.SetActive(false);
                    Obstacles.SetActive(false);
                }
                break;
            case 9:
                if (PlayerPrefs.GetInt("Level9_Finish") == 0)
                {
                    Elements.SetActive(false);
                    Compounds.SetActive(false);
                    Obstacles.SetActive(false);
                }
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
