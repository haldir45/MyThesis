using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour
{


	//attack
	public bool attacking = false;
	public Collider2D attackTrigger;


	private Animator anim;


	void awake()
	{

	}

	// Use this for initialization
	void Start ()
	{		
		anim = gameObject.GetComponent<Animator> ();

		attackTrigger.enabled = false;

	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(anim.GetFloat("moveHorizontal") <0.1 & !anim.GetBool("jumping"))
		   checkAttackingKey ();

	}

	void FixedUpdate()
	{

		attack ();
		resetValues ();
		
	}

	void resetValues(){
		attacking = false;
	}

	void checkAttackingKey(){
		if (Input.GetKeyDown ("g")) 
			attacking = true;
	}
	void attack()
	{
		//attack
		if (attacking && (!this.anim.GetCurrentAnimatorStateInfo (0).IsTag ("attack"))) {
			anim.SetTrigger ("attack");
			attackTrigger.enabled = true;

		} else {
			attackTrigger.enabled = false;
		}
			
	}

}

