using UnityEngine;
using System.Collections;

public class enemyAttackTrigger : MonoBehaviour
{


	enemyAttack enemyAttackObj;
//	enemyBullyHealth enemyBullyHealthObj;
	//public Collider2D attackTrigger;

	void Start(){

		enemyAttackObj = GameObject.FindGameObjectWithTag ("EnemyBully").GetComponent<enemyAttack> ();
		//enemyBullyHealthObj = GameObject.FindGameObjectWithTag ("EnemyBully").GetComponent<enemyBullyHealth> ();
	}

	void Update()
	{

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if ( col.collider.CompareTag ("Player"))
		{
			enemyAttackObj.canAttack = true;
			enemyAttackObj.GetComponent<Animator> ().SetBool ("collideWithObj",true);
		}
	
			
	}

	void OnCollisionStay2D(Collision2D col)
	{
		//if (col.collider.CompareTag ("PlayerAttackTrigger")) {
	
			//enemyBullyHealthObj.addDamage (1);
		//}
	
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if ( col.collider.CompareTag ("Player"))
		{
			enemyAttackObj.GetComponent<Animator> ().SetBool ("collideWithObj",false);
				
		}
	}

}

