using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class SceneChange : MonoBehaviour {

    public string scenename;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (CrossPlatformInputManager.GetButtonDown("Main Menu"))
        {
            SceneManager.LoadScene(scenename);
        }

        else if (CrossPlatformInputManager.GetButtonDown("Play"))
        {
            SceneManager.LoadScene(scenename);
        }

        else if (CrossPlatformInputManager.GetButtonDown("Exit"))
        {
            Application.Quit();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scenename);
        }
    }
}
