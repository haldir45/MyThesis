using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class enemyArcherHealth : MonoBehaviour
{
	public float maxHealth;
    public GameObject healthObj;

    public AudioSource goblinDeathSound;

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
		if (currentHealth == 0) 
		{
            goblinDeathSound.Play();
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
        spawnDiamonds();
        Destroy (gameObject);
        //Destroy (gameObject.GetComponent<enemyBullyController> ());
		gm.diamonds += 1;
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

    void spawnDiamonds(){
        float randomNumber = Random.Range(0.0f, 100.0f);
        if (randomNumber < 30.0f)
        {
            Instantiate(healthObj, transform.position, transform.rotation);

        }
    }

}



