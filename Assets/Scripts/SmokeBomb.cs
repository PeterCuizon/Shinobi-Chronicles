using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : MonoBehaviour {

	public float Timer = 2.0f;
    public float speed = 20f;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb.velocity = transform.right * speed;
    }

	// Update is called once per frame
	void Update () {
        
        Timer -= Time.deltaTime;
		if (Timer <= 0.0f){
			Destroy (gameObject);
		}
	}
}
