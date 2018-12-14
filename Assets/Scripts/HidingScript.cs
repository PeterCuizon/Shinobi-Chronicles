using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HidingScript : MonoBehaviour {

    public GameObject Character;
	bool Hidden = false;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

        if(CrossPlatformInputManager.GetButtonDown("Hide") && Hidden == true)
        {
            Hidden = false;
            Character.SetActive(false);
            print("Hidden = true");
        }

        else if(CrossPlatformInputManager.GetButtonDown("Hide") && Hidden == false)
        {
            Character.SetActive(true);
            print("Hidden = false");
        }

        if(CrossPlatformInputManager.GetButton("Hide"))
        {
            print("Button Pressed");
        }
    }

    public void OnTriggerStay2D(Collider2D other)
	{
        if (other.gameObject.tag == "Player" && Hidden == false)
        {
            Hidden = true;
        }
    }
}