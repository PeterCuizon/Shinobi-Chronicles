using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponScript : MonoBehaviour {

    public float FireRate = 3f;
    public Transform FirePoint;
    public GameObject ShurikenPrefab;
    public GameObject SmokeBombPrefab;
    public bool Fired = false;
    public EquipmentChange equipmentchange;

	// Use this for initialization
	void Start () {
        equipmentchange = FindObjectOfType<EquipmentChange>();
    }
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonDown("Ability") && FireRate >= 3f && equipmentchange.ShurikenActive == true)
        {
            Shuriken();
            Fired = true;
        }
        else if (FireRate < 0)
        {
            Fired = false;
            FireRate = 3f;
        }
        if (CrossPlatformInputManager.GetButtonDown("Ability") && FireRate >= 3f && equipmentchange.SmokeActive == true)
        {
            SmokeBomb();
            Fired = true;
        }
        if (Fired == true)
        {
            FireRate -= Time.deltaTime;
        }
	}
    public void Shuriken ()
    {
        Instantiate(ShurikenPrefab, FirePoint.position, FirePoint.rotation);
    }
    public void SmokeBomb()
    {
        Instantiate(SmokeBombPrefab, FirePoint.position, FirePoint.rotation);
    }
}
