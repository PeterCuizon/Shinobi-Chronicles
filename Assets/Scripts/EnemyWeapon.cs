using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    public float FireRate = 1f;
    public Transform EnemyFirePoint;
    public GameObject BulletPrefab;
    public bool Fired = false;
    public EnemyVision enemyvision;

    // Use this for initialization
    void Start () {
        enemyvision = FindObjectOfType<EnemyVision>();
    }
	
	// Update is called once per frame
	void Update () {

        if (enemyvision.Detected == true)
        {
            if (FireRate > 0 && Fired == false)
            {
                Bullet();
                Fired = true;
            }
        }

        if (FireRate < 0 && Fired == true)
        {
            Fired = false;
            FireRate = 1f;
        }

        if (Fired == true)
        {
            FireRate -= Time.deltaTime;
        }
    }

    public void Bullet()
    {
        Instantiate(BulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
    }
}

