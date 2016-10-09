using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour
{

	public enemyArcherController enemyArcherController;


	void Awake()
	{
		enemyArcherController = gameObject.GetComponentInParent<enemyArcherController> ();

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.CompareTag("Player"))  
		{		
			enemyArcherController.anim.SetBool ("awake", true);
		//	enemyArcherController.attack ();
		}


	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.CompareTag("Player"))  
		{
			enemyArcherController.anim.SetBool ("awake", false);
		}
	}
}

