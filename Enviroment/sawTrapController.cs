using UnityEngine;
using System.Collections;

public class sawTrapController : MonoBehaviour {

	/*
	public float speed;

	private playerController player;

	bool isLeft = false;

	Rigidbody2D rb;

    */

	//Starting Point of Platform
	private Vector3 posA;

	//Ending Point of Platform
	private Vector3 posB;

	//the next position the platform will move
	private Vector3 nextPos;

	public float speed;

	//The childPlatform transform
	public Transform childPlatform;

	//PositionB trasform
	public Transform transformPosB;

	// Use this for initialization
	void Start () {

		/*
		rb = GetComponent<Rigidbody2D> ();
	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<playerController> ();

        */

		posA = childPlatform.localPosition;

		posB = transformPosB.localPosition;
		//Initializing the nextPos
		nextPos = posB;

	}
	
	// Update is called once per frame
	void Update () {
		move ();
		/*
		//sawMechanism.SetActive (true);
		if (isLeft) {
			rb.AddForce ((Vector2.right * speed));
		} else {
			rb.AddForce ((Vector2.left * speed));
		//	Debug.Log("Second Collision Detection");
		}

		Vector3 easeVelocity= rb.velocity; 
		easeVelocity.y = rb.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.95f;

		rb.velocity = easeVelocity;
		*/
	}
	private void move()
	{
		childPlatform.localPosition = Vector3.MoveTowards (childPlatform.localPosition, nextPos, speed * Time.deltaTime);

		if (Vector3.Distance (childPlatform.localPosition, nextPos) <= 0.1)
			changeDistantion ();

	}

	private void changeDistantion()
	{
		nextPos = nextPos != posA ? posA : posB;
	}

	/*
	void OnTriggerEnter2D(Collider2D col)
	{
		

		if(col.CompareTag("LeftSliderMechanism"))
		{
	
				isLeft = true;
		}

		if (col.CompareTag ("RightSliderMechanism")) {
			
			isLeft = false;
		}

		if(col.CompareTag("Player") )
		{
			player.damage (2);
		

		
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.CompareTag("Player") )
		{

			player.damage (2);


		}
	}

	*/
}
