using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
	public Text diamondsT;
	public Text footUIT;

	public int diamonds;
	public int highScore =0;

	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.HasKey ("Score")) 
		{//
			//if (SceneManager.GetActiveScene ().name.Equals("Level1")) 
		//	{
				PlayerPrefs.DeleteKey ("Score");
				diamonds = 0;
		//	} else
		//	{
			//	diamonds = PlayerPrefs.GetInt ("Score");
			//}
		}

		if (PlayerPrefs.HasKey ("HighScore")) {
			highScore = PlayerPrefs.GetInt ("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		diamondsT.text = "X " + diamonds;


	}


}

