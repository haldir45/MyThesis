using UnityEngine;
using System.Collections;

public class playerJumping : MonoBehaviour
{


	//grounded
	public bool grounded; 

	//Physics
	private Rigidbody2D rb;

	//Animation
	private Animator anim;

	public float jumpForce;
	private bool canDoubleJump;

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
	
	}

	void FixedUpdate()
	{
		jump ();
	}

	void jump()
	{

		if(Input.GetButtonDown("Jump") && ( (!anim.GetCurrentAnimatorStateInfo(0).IsTag("attack")) & (!anim.GetCurrentAnimatorStateInfo(0).IsName("hurt")) ) )
		{
			anim.SetBool ("jumping", true);

			//If the player is on the ground,jump and set true canDoubleJump variable
			if (grounded) { //&& !( anim.GetBool("crouch") )
				rb.AddForce (Vector2.up * jumpForce);
				canDoubleJump = true;
				anim.SetBool ("crouch", false);

			} else 
			{//If not the player is on the ground and the canDoubleJump variable is true the player can jump twice 
				if (canDoubleJump) 
				{
					canDoubleJump = false;
					rb.velocity = new Vector2 (rb.velocity.x, 0);
					rb.AddForce(Vector2.up * (jumpForce));

				}
			}

		}

	}


	public void checkGrounded(){
		if(grounded)
			anim.SetBool ("jumping", false);
	}
}

