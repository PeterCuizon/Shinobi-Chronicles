 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class EquipmentChange : MonoBehaviour {

    public int Equipment = 1;
    public bool HookActive = true;
    public bool SmokeActive = false;
    public bool ShurikenActive = false;
    public GameObject HookText;
    public GameObject SmokeText;
    public GameObject ShurikeText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ChangeEquipment();
    }

    public void ChangeEquipment()
    {
        if (CrossPlatformInputManager.GetButtonDown("Equipment"))
        {
            switch (Equipment)
            {
                case 3:
                    print("Hook");
                    HookActive = true;
                    SmokeActive = false;
                    ShurikenActive = false;
                    HookText.SetActive(true);
                    SmokeText.SetActive(false);
                    ShurikeText.SetActive(false);
                    Equipment = 1;
                    break;
                case 2:
                    print("Smoke");
                    HookActive = false;
                    SmokeActive = true;
                    ShurikenActive = false;
                    HookText.SetActive(false);
                    SmokeText.SetActive(true);
                    ShurikeText.SetActive(false);
                    Equipment = 3;
                    break;
                case 1:
                    print("Shuriken");
                    HookActive = false;
                    SmokeActive = false;
                    ShurikenActive = true;
                    HookText.SetActive(false);
                    SmokeText.SetActive(false);
                    ShurikeText.SetActive(true);
                    Equipment = 2;
                    break;
            }
        }
    }
}
