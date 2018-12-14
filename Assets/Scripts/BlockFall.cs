using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFall : MonoBehaviour {

    public GameObject String;
    public GameObject Block;
    public Rigidbody2D RB2D;

	// Use this for initialization
	void Start () {
        RB2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.gameObject.tag == "Shuriken")
            {
                Destroy(String);
                this.RB2D.gravityScale = 100;
            }
        }
    }
}
