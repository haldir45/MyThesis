using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour {

	void Start(){
		Time.timeScale = 1;

	}
	public void startScene(){
		SceneManager.LoadScene("Level1");
	}

	public void Quit(){
		Application.Quit ();
	}
}
