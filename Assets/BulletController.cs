using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public static float speed;
    private BoyleController bigB;

    // Use this for initialization
    void Start () {
   
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.name);

        if(collision.tag == "Fire" && gameObject.name == "WaterBullet(Clone)")
        {
            LevelStatus.totalObstacles--;
            ElementsController.hydrogen = 0;
            ElementsController.oxygen = 0;
            ElementsController.elementList.Clear();
            ElementsController.compound.sprite = null;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "Snail" && gameObject.name == "SaltBullet(Clone)")
        {
            LevelStatus.totalObstacles--;
            ElementsController.sodium = 0;
            ElementsController.chlorine = 0;
            ElementsController.elementList.Clear();
            ElementsController.compound.sprite = null;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "Crates" && gameObject.name == "AcidBullet(Clone)")
        {
            LevelStatus.totalObstacles--;
            ElementsController.hydrogen = 0;
            ElementsController.chlorine = 0;
            ElementsController.elementList.Clear();
            ElementsController.compound.sprite = null;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        //if(collision.tag != "Player")
            
    }
}
