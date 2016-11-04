using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class doorController : MonoBehaviour {

	//animation
	Animator anim;



	public dialogueManager dialogueManagerOBJ;

	//gameManager object
	private gameManager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<gameManager> ();

		//reference to animator
		anim = GetComponent<Animator> ();
		anim.SetBool ("open", false);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			dialogueManagerOBJ.ShowBox("[E] to Enter");

			if(Input.GetKey("e"))
			{

				anim.SetBool ("open", true);
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			dialogueManagerOBJ.ShowBox("[E] to Enter");

			if(Input.GetKey("e"))
			{
				anim.SetBool ("open", true);
			
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			dialogueManagerOBJ.HideBox ();
		}
	}

	void loadNextScene()
	{
		saveScore ();
		setttingTheHighScore ();

        string name = SceneManager.GetActiveScene().name;
        string i = name.Substring(5);


		if(SceneManager.GetActiveScene().name == "Level3")
			SceneManager.LoadScene("MainMenu");
		else
            SceneManager.LoadScene ("Level" + (int.Parse(i)+1));
     
       
	}

	void setttingTheHighScore()
	{
		if (PlayerPrefs.HasKey ("HighScore")) {
			if (PlayerPrefs.GetInt ("HighScore") < gm.diamonds) {
				PlayerPrefs.SetInt ("HighScore", gm.diamonds);
			}
		} else {
			PlayerPrefs.SetInt ("HighScore", gm.diamonds);
		}
	}

	void saveScore()
	{
		PlayerPrefs.SetInt ("Score",gm.diamonds);
	}

}
