using UnityEngine;
using System.Collections;

public class spikeController : MonoBehaviour {

 
	void OnTriggerEnter2D(Collider2D col){

        //KIll player
        if(col.CompareTag("Player") )
            col.GetComponent<Animator>().SetBool("dead", true);
       
        
		//Kill Enemy Bully
        if (col.CompareTag("EnemyBody"))
            col.GetComponent<Animator>().SetBool("dead", true);
    

          
	}
}
