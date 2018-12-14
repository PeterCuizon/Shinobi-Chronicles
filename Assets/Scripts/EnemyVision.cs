using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour {

    public float FollowTimer = 5f;
    public bool Detected = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Detected == true && FollowTimer > 0)
        {
            FollowTimer -= Time.deltaTime;
        }
        else if (Detected == true && FollowTimer < 0)
        {
            Detected = false;
            FollowTimer = 5f;
        }
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Detected = true;
        }
    }
}
