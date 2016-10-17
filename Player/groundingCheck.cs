using UnityEngine;
using System.Collections;

public class groundingCheck : MonoBehaviour {

	private playerController player;
	private playerJumping jumpingObj;
	// Use this for initialization
	void Start () {
	
		player = gameObject.GetComponentInParent<playerController> ();
		jumpingObj =  gameObject.GetComponentInParent<playerJumping> ();
	}


	//Setting true the grounded parameter if the player touches the ground
	void OnTriggerEnter2D(Collider2D col)
	{
		player.grounded = true;
		jumpingObj.grounded = true;
	}
		
	void OnTriggerStay2D(Collider2D col)
	{
		player.grounded = true;
		jumpingObj.grounded = true;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		player.grounded = false;
		jumpingObj.grounded = false;
	}
}
