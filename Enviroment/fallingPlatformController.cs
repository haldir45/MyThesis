using UnityEngine;
using System.Collections;

public class fallingPlatformController : MonoBehaviour {


    //Time before platform starts to fall
    public float fallDelay;
   
    //reference to this game object's Rigidbody2d component
	private Rigidbody2D rb;

	


	// Use this for initialization
	void Start () {
        
		rb = GetComponent<Rigidbody2D> ();
    
	}

	void OnCollisionStay2D(Collision2D col){
        //if player jump to the platform call the fall coroutine
		if (col.collider.CompareTag("Player")) 
			StartCoroutine (Fall ());
		
	}


    //After fallDealy secs platform collapse
	IEnumerator Fall()
	{
		yield return new WaitForSeconds (fallDelay);
		rb.isKinematic = false;
		GetComponent<Collider2D> ().isTrigger = true;
	
	}

}
