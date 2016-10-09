using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class playerController : MonoBehaviour {

		//Physics
		private Rigidbody2D rb;

	    //Collider2D
	private BoxCollider2D coll2D;   

		//Animation
		Animator anim;


		//Movement
		float moveHorizontal = 0.0f;
		public float speed;
    	public float maxSpeed;

		//facing
		private bool facingRight = true;

	    //grounded
	    public bool grounded; 



	    //jump
	private bool jumping;

	    //Player Life
	public int currentHealth;
	public int maxHealth ;
	public bool dead;

	//game master
	private gameManager gm;



		// Use this for initialization
		void Start () {
			//reference to Rigibody2d
			rb = GetComponent<Rigidbody2D> ();

			//reference to animator
			anim = GetComponent<Animator> ();

		   //reference to Collider2D
		coll2D = GetComponent<BoxCollider2D>();

		   //reference to gameManager class
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();

		    //Setting the currentHealth to maxHealth every time the player starts the game
	    	currentHealth = maxHealth;
		}

		// Update is called once per frame
	void Update () {
		   //grounded update
		   anim.SetBool("grounded",grounded);

	     	crouch ();

		resizeCollider2D ();


		    if (currentHealth > maxHealth) {
		    	currentHealth = maxHealth;

		    }

		    if (currentHealth <= 0) 
	     	{
			   dead = true;
			   anim.SetBool ("dead", dead);
		

		     }

		}
		//physics only in FixedUpdate
		void FixedUpdate()
     	{

		easeMoving ();

		moveHorizontal = Input.GetAxis("Horizontal");

		rb.AddForce ((Vector2.right * speed) * moveHorizontal);
			//rb.velocity = new Vector2 (moveHorizontal*speed,0);


		//limiting the speed of the player
		if (rb.velocity.x > maxSpeed) {
			rb.velocity = new Vector2 (maxSpeed, rb.velocity.y);
		}

		if (rb.velocity.x < -maxSpeed) {
			rb.velocity = new Vector2 (-maxSpeed, rb.velocity.y);
		}


		//Update the moveHorizontal parameter in the animator
		anim.SetFloat ("moveHorizontal", Mathf.Abs (rb.velocity.x));



		//Flipping the player

			if ((moveHorizontal > 0) && (!facingRight)) {

				Flip ();

			} else if ((moveHorizontal < 0) && (facingRight)) {
				Flip ();
			}


		}

	void easeMoving(){
		//fake friction velocity
		Vector3 easeVelocity= rb.velocity; 
		easeVelocity.y = rb.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		//fake friction/Easing the x speed of our player
		if (grounded) {
			rb.velocity = easeVelocity;
		}

	}


	void crouch()
	{
		if (Input.GetButtonDown ("LeftControl")) {

			anim.SetBool ("crouch", true);

		}

		if (Input.GetButtonUp ("LeftControl")) {

			anim.SetBool ("crouch", false);

		} 
	
	}

	void die()
	{
		
		setttingTheHighScore ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}



	void setttingTheHighScore()
	{
		if (PlayerPrefs.HasKey ("HighScore")) {
			if (PlayerPrefs.GetInt ("HighScore") < gm.diamonds) {
				PlayerPrefs.SetInt ("HighScore", gm.diamonds);
			}
		} else {
			PlayerPrefs.SetInt ("HighScore", gm.diamonds);
		}
	}



	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Diamonds")) {
			Destroy (col.gameObject);
			gm.diamonds +=1;
		}
			

	}

	public void damage(int dmg)
	{
		if (currentHealth - dmg < 0 | dmg > currentHealth) {
			currentHealth = 0;
		} else {
			currentHealth -= dmg;
		}

	}


	void Flip(){
		facingRight = !facingRight;
		//anim.SetBool("facing",facingRight);

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;

		transform.localScale = theScale;
	}


	void resizeCollider2D ()
	{
		if (anim.GetBool ("crouch")) {

			coll2D.size = new Vector2 (0.74f, 0.70f);
			coll2D.offset = new Vector2 (-0.2f, -0.4f);
		} else {
			coll2D.size = new Vector2 (0.74f, 1.45f);
			coll2D.offset = new Vector2 (-0.2f, 0.0f);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.CompareTag ("movingPlatform"))
			transform.parent = col.transform;
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.transform.CompareTag ("movingPlatform"))
			transform.parent = null;
	}

}
