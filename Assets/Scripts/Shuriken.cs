using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate (new Vector3(Time.deltaTime*0,0,-45));
	}

    public void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.tag != "Player")
        {
        Destroy(gameObject);
        }
	}
}
