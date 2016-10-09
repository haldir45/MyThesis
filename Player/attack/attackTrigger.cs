using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

	public int dmg = 1;


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.isTrigger != true && col.CompareTag ("EnemyArcher"))
		{
			col.SendMessageUpwards ("addDamage", dmg);
			//EnemyHealth enemyHealthObj = GameObject.FindGameObjectWithTag("Enemy").GetComponentInParent<EnemyHealth>();
		//	enemyArcherHealth enemyHealthObj = col.gameObject.GetComponentInParent<enemyArcherHealth>();
		//	enemyHealthObj.addDamage (1);
//			col.gameObject.GetComponent<enemyArcherController> ().anim.SetBool ("attacked", true);

		}

		if (col.isTrigger != true && col.CompareTag ("EnemyBully"))
		{
			//col.SendMessageUpwards ("damage", dmg);
			//EnemyHealth enemyHealthObj = GameObject.FindGameObjectWithTag("Enemy").GetComponentInParent<EnemyHealth>();
			enemyBullyHealth enemyHealthObj = col.gameObject.GetComponentInParent<enemyBullyHealth>();
			enemyHealthObj.addDamage (1);
			//			col.gameObject.GetComponent<enemyArcherController> ().anim.SetBool ("attacked", true);

		}


	}
		
    
}
