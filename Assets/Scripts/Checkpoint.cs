using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public LevelManager levelmanager;

	// Use this for initialization
	void Start () {
		levelmanager = FindObjectOfType<LevelManager>();
	}

	// Update is called once per frame
	void Update () {

	}

    public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			levelmanager.CheckpointPlace = gameObject;
		}
	}
}
