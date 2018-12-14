using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CheckpointPlace;
	private PlayerScript player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerScript>();
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void RespawnPlayer()
	{
		player.transform.position = CheckpointPlace.transform.position;
	}
}
