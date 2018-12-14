using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 30f;
    public Rigidbody2D rb;
    public float bulletlife = 2f;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        bulletlife -= Time.deltaTime;

        if (bulletlife < 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
