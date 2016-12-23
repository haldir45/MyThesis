using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{

        //Does 1 damage to player and destroys the arrow
		if (col.CompareTag ("Player")) {
			col.GetComponent<playerController> ().damage (1);

			Destroy (gameObject);

		}//Destroys arrow when it collides with ground
        else if (col.CompareTag ("Ground"))
			Destroy (gameObject);
	}
}
