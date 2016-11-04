using UnityEngine;
using System.Collections;

public class spikeController : MonoBehaviour {
	public playerController player;
    public enemyBullyHealth enemy;

	void Start()
	{
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player") )
		{
			player.GetComponent<BoxCollider2D> ().isTrigger = false;
			player.GetComponent<Animator>().SetBool("dead",true);
			gameObject.GetComponent<Collider2D> ().isTrigger = false;

	
		}
        if (col.CompareTag("EnemyBody"))
        {
            enemy.GetComponent<BoxCollider2D> ().isTrigger = false;
            enemy.GetComponent<Animator>().SetBool("dead", true);
            gameObject.GetComponent<Collider2D> ().isTrigger = false;
        }
            
	}
}
