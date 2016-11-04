using UnityEngine;
using System.Collections;

public class sawCollisionDetection: MonoBehaviour
{   
	 public playerController player;
    public enemyBullyHealth enemy;

	// Use this for initialization
	void Start () {



	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player") )
			player.damage (2);
		

		
	
   
        if (col.CompareTag("EnemyBody"))
            enemy.GetComponent<Animator>().SetBool("dead", true);
        
        

	}


		



}

