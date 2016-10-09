using UnityEngine;
using System.Collections;

public class spikeController : MonoBehaviour {
	private playerController player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<playerController> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player") )
		{
			player.GetComponent<BoxCollider2D> ().isTrigger = false;
			player.damage (5);
			gameObject.GetComponent<Collider2D> ().isTrigger = false;

	
		}
	}
}
