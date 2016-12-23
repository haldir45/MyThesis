using UnityEngine;
using System.Collections;

public class playerJumping : MonoBehaviour
{


	//grounded
	public bool grounded; 

    public AudioSource playerJump;

	//Physics
	private Rigidbody2D rb;

	//Animation
	private Animator anim;

	public float jumpForce;
	private bool canDoubleJump;
	private bool jumpKeyPressed;

	// Use this for initialization
	void Start ()
	{

		rb = gameObject.GetComponent<Rigidbody2D> ();


		anim = gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		//grounded = anim.GetBool("grounded");
		//grounded update
		anim.SetBool("grounded",grounded);

		checkGrounded ();
		checkIfJumpKeyPressed ();
	
	}

	void FixedUpdate()
	{

		jump ();
		resetValues();
	}

	void checkIfJumpKeyPressed (){
		if (Input.GetButtonDown ("Jump") && ((!anim.GetCurrentAnimatorStateInfo (0).IsTag ("attack")) & (!anim.GetCurrentAnimatorStateInfo (0).IsName ("hurt")) & (!anim.GetCurrentAnimatorStateInfo (0).IsName ("dead")))) {
			jumpKeyPressed = true;
            playerJump.Play();
			anim.SetBool ("jumping", true);
		}
	}
	void resetValues (){
		jumpKeyPressed = false;
	}
	void jump()
	{
		//If the player is on the ground,jump and set true canDoubleJump variable
		if (grounded & jumpKeyPressed) { 
			//rb.AddForce (Vector2.up * jumpForce);
			rb.AddForce(new Vector2(0,jumpForce));
			canDoubleJump = true;
			anim.SetBool ("crouch", false);//Stops the crouch animation

		} else if(jumpKeyPressed)
		{//If not the player is on the ground and the canDoubleJump variable is true the player can jump twice 
			if (canDoubleJump) 
			{
				canDoubleJump = false;
				rb.velocity = new Vector2 (rb.velocity.x, 0);
				rb.AddForce(new Vector2(0,jumpForce));

			}
		}


	}


	public void checkGrounded(){
		if(grounded)
			anim.SetBool ("jumping", false);
	}
}

