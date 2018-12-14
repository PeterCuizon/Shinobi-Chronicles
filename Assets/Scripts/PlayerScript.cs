using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	public bool facingRight = true;
	public bool isGrounded;
    public bool crouched = false;
    public float DirectionX;
    public Rigidbody2D RB;
    public float health = 3;
    public LevelManager levelManager;
    public EnemyVision enemyVision;

    void Start ()
	{
        RB = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
        enemyVision = FindObjectOfType<EnemyVision>();
    }

    void Update ()
	{
        DirectionX = CrossPlatformInputManager.GetAxis("Horizontal");

        if (CrossPlatformInputManager.GetButtonDown("Right"))
        {
            WalkRight();
            facingRight = true;
        }
        if (CrossPlatformInputManager.GetButtonDown("Left"))
        {
            WalkLeft();
            facingRight = false;
        }
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
        Jump();
        }
        
        if (health <=0)
        {
            health = 3;
            levelManager.RespawnPlayer();
            enemyVision.Detected = false;
        }
    }

    public void FixedUpdate()
    {
        RB.velocity = new Vector2(DirectionX * moveSpeed, RB.velocity.y);
    }

	public void OnTriggerEnter2D(Collider2D other)
	{
		isGrounded = true;
		if ((other.gameObject.tag == "Crouch") && crouched == false)
		{
			crouched = true;
            transform.localScale -= new Vector3(0, 1, 0);
        }
    }
	public void OnTriggerStay2D(Collider2D other)
	{
		isGrounded = true;
    }
	public void OnTriggerExit2D(Collider2D other)
	{
		isGrounded = false;
        if ((other.gameObject.tag == "Crouch") && crouched == true)
        {
            crouched = false;
            transform.localScale += new Vector3 (0, 1, 0);
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health -= 1;
            print(health);
        }
    }

    public void WalkLeft()
    {
        if (facingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = false;
        }
    }

    public void WalkRight()
    {
        if (facingRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }
    }

    public void Jump ()
    {
        if (isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Force);
        }
    }
}