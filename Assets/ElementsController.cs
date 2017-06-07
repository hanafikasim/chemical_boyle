using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementsController : MonoBehaviour {

    public static List<GameObject> elementList;

    public static int hydrogen, oxygen, sodium, chlorine;

    public static GameObject water, salt, acid;

    public static Image compound;
    public static Text compoundTxt;
    public Sprite sprWater, sprSalt, sprAcid, sprDefault;

    // Use this for initialization
    void Start () {
        hydrogen = 0;
        oxygen = 0;
        sodium = 0;
        chlorine = 0;

        elementList = new List<GameObject>();

        //water = GameObject.FindGameObjectWithTag("Water");
        //salt = GameObject.FindGameObjectWithTag("Salt");
        //acid = GameObject.FindGameObjectWithTag("Acid");

        compound = GameObject.FindGameObjectWithTag("Compound").GetComponent<Image>();
        compoundTxt = GameObject.FindGameObjectWithTag("CompoundText").GetComponent<Text>();

        //water.SetActive(false);
        //salt.SetActive(false);
        //acid.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log("Hydrogen :" + hydrogen);
        Debug.Log("Oxygen :" + oxygen);
        Debug.Log("Sodium :" + sodium);
        Debug.Log("Chlorine :" + chlorine);

        //if (elementList != null)
        //{
        //    foreach (GameObject e in elementList)
        //    {
        //        if (e.name == "H")
        //        {
        //            hydrogen++;
        //        }
        //        else if (e.name == "O")
        //        {
        //            oxygen++;
        //        }
        //        else if (e.name == "Na")
        //        {
        //            sodium++;
        //        }
        //        else if (e.name == "Cl")
        //        {
        //            chlorine++;
        //        }
        //    }
        //}


        if (hydrogen == 2 && oxygen == 1)
        {
            //water.SetActive(true);
            compound.sprite = sprWater;
            compoundTxt.text = "Water";
        }
        else if (sodium == 1 && chlorine == 1)
        {
            compound.sprite = sprSalt;
            compoundTxt.text = "Salt";
            //salt.SetActive(true);
        }
        else if (hydrogen == 1 && chlorine == 1)
        {
            compound.sprite = sprAcid;
            compoundTxt.text = "Acid";
            //acid.SetActive(true);
        }
        else
        {
            compound.sprite = sprDefault;
            compoundTxt.text = " ";
            //water.SetActive(false);
            //salt.SetActive(false);
            //acid.SetActive(false);
        }
    }

    public void Discard()
    {
        GameObject obj;
        obj = elementList[elementList.Count-1];
        obj.SetActive(true);
        elementList.RemoveAt(elementList.Count - 1);

        switch (obj.name)
        {
            case "H":
                hydrogen--;
                break;
            case "O":
                oxygen--;
                break;
            case "Na":
                sodium--;
                break;
            case "Cl":
                chlorine--;
                break;
        }
    }
}
