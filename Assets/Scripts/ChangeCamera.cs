using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

	public GameObject CameraOn;
	public GameObject CameraOff;
    public GameObject DeloadEnemy;
    public GameObject UnloadEnemy;
    public GameObject DeloadHiding;
    public GameObject UnloadHiding;

    void Start () {
		
	}

	void Update () {		
	}

    public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			CameraOn.SetActive (true);
			CameraOff.SetActive (false);
            DeloadEnemy.SetActive(false);
            UnloadEnemy.SetActive(true);
            DeloadHiding.SetActive(false);
            UnloadHiding.SetActive(true);
        }
	}
}
