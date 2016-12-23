using UnityEngine;
using System.Collections;

public class groundingCheck : MonoBehaviour {

	private playerController player;
	private playerJumping jumpingObj;

   // Animator anim;
	// Use this for initialization
	void Start () {
	
		player = gameObject.GetComponentInParent<playerController> ();
		jumpingObj =  gameObject.GetComponentInParent<playerJumping> ();

    //    anim = GetComponentInParent<Animator>();
	}


	//Setting true the grounded parameter if the player touches the ground
	void OnTriggerEnter2D(Collider2D col)
	{
        if (col.CompareTag("EnemyArcher")||col.CompareTag("EnemyBully"))
            return;
	     else{
           // anim.SetBool("OnTopOfAnEnemy",false);
            player.grounded = true;
            jumpingObj.grounded = true;
         }

      //  player.grounded = true;
      //  jumpingObj.grounded = true;

	}
		
	void OnTriggerStay2D(Collider2D col)
	{
		
        if (col.CompareTag("EnemyArcher")||col.CompareTag("EnemyBully"))
           return;
			else{
           // anim.SetBool("OnTopOfAnEnemy",false);
            player.grounded = true;
            jumpingObj.grounded = true;
			
			}

	}
	void OnTriggerExit2D(Collider2D col)
	{
       // anim.SetBool("OnTopOfAnEnemy",false);
		player.grounded = false;
		jumpingObj.grounded = false;
	}
}
