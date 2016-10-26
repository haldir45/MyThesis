using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour
{

	//attack
	public bool attacking = false;
	private float attackTimer =0;
	public float attackCd;
	public bool canAttack = false;
	public bool startCD=false;
	//private bool endCD = false;

	private Animator anim;

	public int dmg = 1;

	public playerController player;

	void awake()
	{

	}

	// Use this for initialization
	void Start ()
	{		
		anim = gameObject.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update ()
	{

	//	Debug.Log ("canattack" + canAttack + ", startCD:" + startCD);
		if (canAttack & anim.GetBool("collideWithObj"))
			anim.SetBool ("attacking", true);

		if (startCD) {
			anim.SetBool ("attacking", false);
			attack ();
		}

	}

	void attack()
	{
		attackTimer += Time.deltaTime;
	
		if (attackTimer >=attackCd) {
			canAttack = true;
			attackTimer = 0;
			startCD = false;
		} 

	
	

	}

	public void doDamage(){
		
		player.damage(1);
		canAttack = false;
		startCD = true;

	
	}
}

