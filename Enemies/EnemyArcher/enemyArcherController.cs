using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class enemyArcherController : MonoBehaviour {


	//enemy shooting
	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float arrowSpeed = 100;
	public float arrowTimer;
	public GameObject arrow;
	public Transform shootPoint;

	//enemy facing
	public bool facingRight = true;

	//Targets
	public GameObject player;
	public Transform target;

	//enemy animator
	public Animator anim;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () 
	{
		

		
		rangeCheck ();

		if (transform.position.x > target.transform.position.x && (facingRight)) {
			Flip ();
		} else if (transform.position.x < target.transform.position.x && (!facingRight)){
			Flip ();
		}
			
	}

    IEnumerator deathAnimationTimer()
	{
		yield return new WaitForSeconds (0.75f);
	   anim.SetBool ("dead", true);  
    }


	void Flip(){
		facingRight = !facingRight;
		//anim.SetBool("facing",facingRight);

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;
		transform.localScale = theScale;
	}


	void rangeCheck()
	{
		distance = Vector3.Distance (transform.position, target.transform.position);
	}

	public void attack()
	{
		//arrowTimer += Time.deltaTime;
	
			if ( (!player.GetComponent<playerController>().dead) && (!anim.GetBool("dead"))) {
			//arrowTimer >= shootInterval &&
			//arrowTimer += Time.deltaTime;

			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();

			GameObject arrowClone;
			arrowClone = Instantiate (arrow, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
			if (!facingRight) {
				Vector3 theScale = arrowClone.transform.localScale;
				theScale.x *= -1;
				arrowClone.transform.localScale = theScale;
			}
			arrowClone.GetComponent<Rigidbody2D> ().velocity = direction * arrowSpeed;
			//arrowTimer = 0;
		}
	}







}
