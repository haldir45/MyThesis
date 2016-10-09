using UnityEngine;
using System.Collections;

public class enemyBullyController : MonoBehaviour {


	//Physics
	Rigidbody2D rb;

	//Animation
	Animator anim;

	//enemy facing
	public bool facingRight = true;

	//Targets
	public GameObject player;
	public Transform target;

	//Charge
	public float chargeTime;
	float startChargeTime;
//	bool charging;
	public float speed;

	//attack
	public bool attacked;

	// Use this for initialization
	void Start () {
		//reference to Rigibody2d
		rb = GetComponent<Rigidbody2D> ();

		//reference to animator
		anim = GetComponentInChildren<Animator> ();

		attacked = false;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x > target.transform.position.x && (facingRight)) {
			Flip ();
		} else if (transform.position.x < target.transform.position.x && (!facingRight)){
			Flip ();
		}

		//Update the moveHorizontal parameter in the animator
		anim.SetFloat ("moveHorizontal", Mathf.Abs (rb.velocity.x));
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) { 
			//charging = true;
			startChargeTime = Time.time + chargeTime;
			anim.SetBool ("sleeping", false);
			anim.SetBool ("attacking", false);
		}

	}


	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player") & (!attacked) & (!anim.GetBool("collideWithObj"))) { 

			if (startChargeTime < Time.time) {
				if (!facingRight)
					rb.AddForce ((Vector2.left * speed));
				else
					rb.AddForce ((Vector2.right * speed));
				anim.SetBool ("sleeping", false);
				//anim.SetBool ("charging", charging);
			}

		}

	}

	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Player")) { 
		//	charging = false;
			//anim.SetBool ("charging", charging);
			rb.velocity = new Vector2 (0f, 0f);
			anim.SetBool ("sleeping", true);


		}
	}
	void Flip(){
		facingRight = !facingRight;
		//anim.SetBool("facing",facingRight);

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;
		transform.localScale = theScale;
	}



}
