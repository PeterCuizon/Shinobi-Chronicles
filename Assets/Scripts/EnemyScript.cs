using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public Transform[] Waypoints;
    public float Speed = 5f;
    Transform CurrentWaypoint;
    int CurrentWaypointIndex;
    public bool smoked = false;
    public float frozen = 5f;
    public GameObject EnemeyVision;
    public EnemyVision enemyvision;

    // Use this for initialization
    void Start()
    {
        CurrentWaypointIndex = 0;
        CurrentWaypoint = Waypoints[CurrentWaypointIndex];
        enemyvision = FindObjectOfType<EnemyVision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (smoked == false && enemyvision.Detected == false)
        {
            frozen = 5f;
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            EnemeyVision.SetActive(true);
            if (Vector3.Distance(transform.position, CurrentWaypoint.position) < .1f)
            {
                if (CurrentWaypointIndex + 1 < Waypoints.Length)
                {
                    CurrentWaypointIndex++;
                }

                else
                {
                    CurrentWaypointIndex = 0;
                }

                CurrentWaypoint = Waypoints[CurrentWaypointIndex];
            }
        }

        else if (smoked == true && frozen >= 0)
        {
            frozen -= Time.deltaTime;
            EnemeyVision.SetActive(false);
        }

        if (frozen <= 0)
        {
            smoked = false;
        }

        Vector3 WaypointDirection = CurrentWaypoint.position - transform.position;
        float angle = Mathf.Atan2(WaypointDirection.x, WaypointDirection.y) * Mathf.Rad2Deg - 90f;

        Quaternion Quat = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quat, 180f);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shuriken")
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SmokeBomb" )
        {
            smoked = true;
        }

        if (other.gameObject.tag == "DeathBlock")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            if (Input.GetMouseButtonUp(0))
            {
            Destroy(gameObject);
            }

        }
    }
}
