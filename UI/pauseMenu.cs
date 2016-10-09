using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class pauseMenu : MonoBehaviour {


	public GameObject PauseUI;

	private bool paused = false;


	// Use this for initialization
	void Start () {
		PauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		} else {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Resume(){
		paused = false;

	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void mainMenu(){
		//Right now i dont have a main menu,So load again the active scene
		//SceneManager.LoadScene ("Main Menu");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
		
	public void Quit(){
		Application.Quit ();
	}


}
