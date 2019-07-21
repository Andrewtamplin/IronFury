using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aud : MonoBehaviour 
{

    // Use this for initialization

    public float speed = 0.5F;
    public Rigidbody2D  player;
    public Rigidbody2D Shotspawn;
    public ConstantForce2D thrust;
    void Start()
    {
        // Sets the direction that shot is fired in.
        if (player.rotation.Equals(90))
        {
            thrust.force = Vector2.left;
        }
        else if(player.rotation.Equals(0))
        {
            thrust.force = Vector2.up;
        }
        else if(player.rotation.Equals(180))
        {
            thrust.force = Vector2.down;
        }
        else
        {
            thrust.force = Vector2.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}