using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj2 : MonoBehaviour {

    float constantSpeed = 10f;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		rb.velocity = constantSpeed * (rb.transform.up);
        Destroy(gameObject, .5f);
    }
}
