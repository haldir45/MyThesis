using UnityEngine;
using System.Collections;

public class fallingPlatformController : MonoBehaviour {


	private Rigidbody2D rb;

	public float fallDelay;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.collider.CompareTag("Player")) {
			
			StartCoroutine (Fall ());
		}
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds (fallDelay);
		rb.isKinematic = false;

		GetComponent<Collider2D> ().isTrigger = true;
		yield return 0;
	}

}
