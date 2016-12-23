using UnityEngine;
using System.Collections;

public class sawCollisionDetection: MonoBehaviour
{   



	void OnTriggerEnter2D(Collider2D col){
        //Do 2 damage to player
		if(col.CompareTag("Player") )
            col.GetComponent<playerController>().damage(2);
		
        //Kill Enemy bully
        if (col.CompareTag("EnemyBody"))
            col.GetComponent<Animator>().SetBool("dead", true);
     
	}


		

}

