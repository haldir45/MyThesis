using UnityEngine;
using System.Collections;

public class playerDefend : MonoBehaviour {

	private Animator anim;
	private bool defending;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//checkDefendingKey ();
		defend1();
	}


	void defend1()
	{
		if (Input.GetKeyDown ("c")) {

			anim.SetBool ("defendStand", true);

		}

		if (Input.GetKeyUp ("c")) {

			anim.SetBool ("defendStand", false);

		} 

	}

	void FixedUpdate()
	{
		//defend ();
		//resetValues ();
	}


	void resetValues(){
		defending = false;
	}

	void checkDefendingKey(){
		if (Input.GetKeyDown ("c")) {
			Debug.Log ("Key C is Pressed");
			defending = true;
		}
			
	}
	void defend()
	{
		//attack
		if (defending && (!this.anim.GetCurrentAnimatorStateInfo (0).IsTag ("defendStand"))) {
			anim.SetTrigger ("defendStand");

		} 

	}
}
