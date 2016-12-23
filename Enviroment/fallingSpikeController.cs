using UnityEngine;
using System.Collections;

public class fallingSpikeController : MonoBehaviour {

    //Reference to parent game object's Rigidbody2d component
    public Rigidbody2D rb;


    //Time before spikes starts to fall
	public float fallDelay;



    void OnCollisionEnter2D(Collision2D col){
        //If player jump to the spikes call the fall coroutine
        if (col.collider.CompareTag("Player")) 
            StartCoroutine (Fall ());
        
    }

	IEnumerator Fall(){
        
        //After fallDealy secs spikes collapse
		yield return new WaitForSeconds (fallDelay);
      
		rb.isKinematic = false;

		GetComponent<Collider2D> ().isTrigger = true;
		
	}

}
