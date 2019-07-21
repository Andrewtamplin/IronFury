using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{

    // Use this for initialization
    public delegate void winEvent();
    public static event winEvent destroyAction;
    public float speed = 0;
    public Vector2 playerSpeed;
    public Rigidbody2D  player;
    void Start()
    {

    }

     void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Blue")
        {
            //Destroy(Collider.gameObject); 
            Destroy(gameObject);
            TankGameUI.winnerFlag = 2;
            destroyAction();
        }
        else if (Collider.gameObject.tag == "Red")
        {
            //Destroy(Collider.gameObject);
            Destroy(gameObject);
            TankGameUI.winnerFlag = 1;
            destroyAction();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}