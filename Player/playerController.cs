using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class playerController : MonoBehaviour {

    public AudioSource playerDeathSound;
    public AudioSource diamondCollectSound;
    public AudioSource playerWalkSound;
    public AudioSource playerDefendSound;
  
    public AudioSource playerHurtSound;

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
		public bool facingRight;

	    //grounded
	    public bool grounded; 



	    //jump
	private bool jumping;

	    //Player Life
	public int currentHealth;
    public int maxHealth;
	public bool dead;

	//game master
	private gameManager gm;

    public bool hasKey;
    //backgroundMusic
    private GameObject backgroundMusicObject;

    private bool pressed = false;




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
        backgroundMusicObject = GameObject.FindGameObjectWithTag("Music");
        
     


     //   gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.8f);
     
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

        playerWalkSoundController();

     
		}
		//physics only in FixedUpdate
		void FixedUpdate(){

           moveHorizontal = Input.GetAxis("Horizontal");

        if ((this.anim.GetCurrentAnimatorStateInfo(0).IsTag("attack")) || (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("dead")) || (this.anim.GetCurrentAnimatorStateInfo(0).IsName("hurt")))
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        else
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

		//Flipping the player
		   Flip(moveHorizontal);

		  //Update the moveHorizontal parameter in the animator
		  anim.SetFloat ("moveHorizontal", Mathf.Abs (rb.velocity.x));
		}
		

    public void playerWalkSoundController(){

       
        /*
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
           playerWalkSound.Stop();
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) & grounded)
          playerWalkSound.Play();
          */
        
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) 
          || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) & grounded & (!pressed)){
            pressed = true;
            playerWalkSound.Play();
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)
            || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)){
            pressed = false;
            playerWalkSound.Stop();

        }

         
        /*
        if (anim.GetFloat("moveHorizontal") > 0.1f)
        {
            Debug.Log(anim.GetFloat("moveHorizontal"));
            playerWalkSound.Play();
        }
          
        else
            playerWalkSound.Stop();
             */

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
		
       // playerDeath.Play();
		setttingTheHighScore ();


        StartCoroutine(restartTheScene());



		
	}

    IEnumerator restartTheScene(){
        backgroundMusicObject.GetComponent<AudioSource>().Stop();


        playerDeathSound.Play();

        yield return new WaitForSeconds(playerDeathSound.clip.length);

        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

    }



	void setttingTheHighScore()
	{
		if (PlayerPrefs.HasKey ("HighScore")) {
			if (PlayerPrefs.GetInt ("HighScore") < gm.diamonds) 
				PlayerPrefs.SetInt ("HighScore", gm.diamonds);
			
		} else 
			PlayerPrefs.SetInt ("HighScore", gm.diamonds);
		
	}






	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Diamonds")) {
            diamondCollectSound.Play();
            Destroy (col.gameObject);
            gm.addDiamonds();
		}

        if (col.CompareTag("Key"))
        {
            diamondCollectSound.Play();
            hasKey = true;
            Destroy(col.gameObject);
            gm.keys += 1;
        }
			

	}

	public void damage(int dmg)
	{


   
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("defendStand"))
        {
            playerHurtSound.Play();
            anim.SetTrigger("hurt");
            if (dmg > currentHealth)

                currentHealth = 0;
            else
            currentHealth -= dmg;
        }
        else
            playerDefendSound.Play();

	}


	void Flip(float moveHorizontal){
		
        if (moveHorizontal > 0 && !facingRight || moveHorizontal < 0 && facingRight)
        {
            
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
     
		/*
		if (moveHorizontal > 0 && !facingRight) {
			transform.eulerAngles = new Vector3 (0, 0,-2*transform.eulerAngles.z);
			facingRight = true;
		}
	
		if (moveHorizontal < 0 && facingRight) {
			transform.eulerAngles = new Vector3 (0, 180,-2*transform.eulerAngles.z);
			facingRight = false;
		}
				*/

	}


	void resizeCollider2D ()
	{
		if (anim.GetBool ("crouch")) {

			coll2D.size = new Vector2 (0.74f, 0.93f);
			coll2D.offset = new Vector2 (-0.2f, 0.1f);
		} else {
			coll2D.size = new Vector2 (0.74f, 1.18f);
			coll2D.offset = new Vector2 (0.1f, 0.24f);
			//coll2D.size = new Vector2 (0.74f, 1.18f);
			//coll2D.offset = new Vector2 (-0.2f, -0.18f);
		}
	}

    public void addHealth(){
     
        if(currentHealth != maxHealth)
        currentHealth += 1;
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
