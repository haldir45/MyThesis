using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour
{


	//attack
	public bool attacking = false;
	private float attackTimer =0;
	public float attackCd;
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
	
		attack ();


	

	}

	void attack()
	{
		//attack
		if (Input.GetKey ("g") && !attacking)
		{
			attacking = true;
			attackTimer = attackCd;

			attackTrigger.enabled = true;

		}

		//checking if the attack animation is over

		if (attacking)
		{
			if (attackTimer > 0)
			{
				attackTimer -= Time.deltaTime;
			} else
			{
				attacking = false;
				attackTrigger.enabled = false;

			}
		}

		//setting the boolean attacking parameter
		anim.SetBool ("attacking", attacking);
	}

}

