using UnityEngine;
using System.Collections;

public class sawCollisionDetection: MonoBehaviour
{
	private playerController player;

	// Use this for initialization
	void Start () {


	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<playerController> ();


	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player") )
		{
			player.damage (2);
		

		
		}

	}
		



}

