using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerMovement : MonoBehaviour
{
    private int dir;
    private int dir2;
    public float speed;
    public Rigidbody2D rb2;
    public Projectile Clone;
    public bool player1;
    private string[] p1Controls = { "up", "left", "down", "right", "m" };
    private string[] p2Controls = { "w", "a", "s", "d", "b" };


    void Update()
    {
        if (player1)
        {

            if (Input.GetKey(p1Controls[0]) && !Input.GetKey(p1Controls[1]) && !Input.GetKey(p1Controls[3]))
            {
                rb2.AddForce(Vector2.up * speed);
                rb2.rotation = 0f;
                dir = 1;
            }

            if (Input.GetKey(p1Controls[1]))
            {
                rb2.AddForce(-Vector2.right * speed);
                rb2.rotation = 90f;
                dir = 3;
            }

            if (Input.GetKey(p1Controls[2]) && !Input.GetKey(p1Controls[1]) && !Input.GetKey(p1Controls[3]))
            {
                rb2.AddForce(-Vector2.up * speed);
                rb2.rotation = 180f;
                dir = 2;
            }

            if (Input.GetKey(p1Controls[3]))
            {
                rb2.AddForce(Vector2.right * speed);
                rb2.rotation = -90f;
                dir = 4;
            }
            if (Input.GetKeyUp(p1Controls[4]))
            {
                fire(dir);
            }
        }
        else
        {
            if (Input.GetKey(p2Controls[0]) && !Input.GetKey(p2Controls[1]) && !Input.GetKey(p2Controls[3]))
            {
                rb2.AddForce(Vector2.up * speed);
                rb2.rotation = 0f;
                dir2 = 1;
            }

            if (Input.GetKey(p2Controls[1]))
            {
                rb2.AddForce(-Vector2.right * speed);
                rb2.rotation = 90f;
                dir2 = 3;
            }

            if (Input.GetKey(p2Controls[2]) && !Input.GetKey(p2Controls[1]) && !Input.GetKey(p2Controls[3]))
            {
                rb2.AddForce(-Vector2.up * speed);
                rb2.rotation = 180f;
                dir2 = 2;
            }

            if (Input.GetKey(p2Controls[3]))
            {
                rb2.AddForce(Vector2.right * speed);
                rb2.rotation = -90f;
                dir2 = 4;
            }
            if (Input.GetKeyUp(p2Controls[4]))
            {
                fire(dir2);
            }

        }
    }
    public void fire(int dir3)
    {
        switch (dir3)
        {


            case 1:               
                Instantiate(Clone, transform.position + (Vector3.up), (transform.rotation));
                Debug.Log("fire 1");
                break;
            case 2:
                Instantiate(Clone, transform.position + (Vector3.down), (transform.rotation));
                Debug.Log("fire 2");
                break;
            case 3:
                Instantiate(Clone, transform.position + (Vector3.left), (transform.rotation));
                Debug.Log("fire 3");
                break;
            case 4:
                Instantiate(Clone, transform.position + (Vector3.right), (transform.rotation));
                Debug.Log("fire 4");
                break;
        }

        Clone.player = rb2;
        Clone.playerSpeed = rb2.velocity;


    }

}
