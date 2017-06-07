using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStatus : MonoBehaviour {

    public int LevelId;
    public static int totalObstacles;

	// Use this for initialization
	void Start () {
        switch (LevelId)
        {
            case 1:
                totalObstacles = PlayerPrefs.GetInt("Level1_Finish");
                break;
            case 2:
                totalObstacles = PlayerPrefs.GetInt("Level2_Finish");
                break;
            case 3:
                totalObstacles = PlayerPrefs.GetInt("Level3_Finish");
                break;
            case 4:
                totalObstacles = PlayerPrefs.GetInt("Level4_Finish");
                break;
            case 5:
                totalObstacles = PlayerPrefs.GetInt("Level5_Finish");
                break;
            case 6:
                totalObstacles = PlayerPrefs.GetInt("Level6_Finish");
                break;
            case 7:
                totalObstacles = PlayerPrefs.GetInt("Level7_Finish");
                break;
            case 8:
                totalObstacles = PlayerPrefs.GetInt("Level8_Finish");
                break;
            case 9:
                totalObstacles = PlayerPrefs.GetInt("Level9_Finish");
                break;

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (totalObstacles == 0)
        {
            switch (LevelId)
            {
                case 1:
                    PlayerPrefs.SetInt("Level1_Finish", totalObstacles);
                    break;
                case 2:
                    PlayerPrefs.SetInt("Level2_Finish", totalObstacles);
                    break;
                case 3:
                    PlayerPrefs.SetInt("Level3_Finish", totalObstacles);
                    break;
                case 4:
                    PlayerPrefs.SetInt("Level4_Finish", totalObstacles);
                    break;
                case 5:
                    PlayerPrefs.SetInt("Level5_Finish", totalObstacles);
                    break;
                case 6:
                    PlayerPrefs.SetInt("Level6_Finish", totalObstacles);
                    break;
                case 7:
                    PlayerPrefs.SetInt("Level7_Finish", totalObstacles);
                    break;
                case 8:
                    PlayerPrefs.SetInt("Level8_Finish", totalObstacles);
                    break;
                case 9:
                    PlayerPrefs.SetInt("Level9_Finish", totalObstacles);
                    break;

            }
        }
        
	}
}
