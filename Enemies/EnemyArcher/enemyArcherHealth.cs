using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class enemyArcherHealth : MonoBehaviour
{
	public float maxHealth;

	float currentHealth;

	//enemy animator
	Animator anim;

	//game master
	private gameManager gm;


	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		currentHealth = maxHealth;

		//reference to gameManager class
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void addDamage(float damage){
		currentHealth -= damage;
		if (currentHealth <= 0) 
		{
			gameObject.GetComponent<Collider2D> ().enabled=false;
			StartCoroutine (deathAnimationTimer ());

		}
	}

	IEnumerator deathAnimationTimer()
	{
		yield return new WaitForSeconds (0.75f);
		anim.SetBool ("dead", true);  
	}

	void die()
	{
		Destroy (gameObject);
		//Destroy (gameObject.GetComponent<enemyBullyController> ());
		gm.diamonds += 1;
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}



