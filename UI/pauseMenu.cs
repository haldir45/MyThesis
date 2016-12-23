using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class pauseMenu : MonoBehaviour {

   

	public GameObject pauseUI;

    public GameObject pauseObject;

    public GameObject  optionsObject;

    public AudioSource backgroundMusic;

	private bool paused = false;



    public AudioSource buttonClickSound;


	// Use this for initialization
	void Start () {
 
		pauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;

            pauseObject.SetActive(true);
            optionsObject.SetActive(false);

		}

		if (paused) {
			pauseUI.SetActive (true);
            backgroundMusic.Pause();
			Time.timeScale = 0;
		} else {
			pauseUI.SetActive (false);
			Time.timeScale = 1;
            backgroundMusic.UnPause();
       
		}
	}

	public void Resume(){

		paused = false;

	}

	public void Restart(){
      
        StartCoroutine(reloadLevel());

	}

    IEnumerator reloadLevel(){
        buttonClickSound.Play();
        paused = false;
        yield return new WaitForSeconds(buttonClickSound.clip.length);
       

       SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void mainMenu(){

        StartCoroutine(loadMainMenu());




    }

    IEnumerator loadMainMenu(){
        buttonClickSound.Play();
        paused = false;

        yield return new WaitForSeconds(buttonClickSound.clip.length);

        SceneManager.LoadScene("MainMenu");

    }
        
    public void Options(){


        pauseObject.SetActive(false);
        optionsObject.SetActive(true);
        
    }

		
	public void Quit(){

        StartCoroutine(closeTheGame());
		
	}

    IEnumerator closeTheGame(){
        buttonClickSound.Play();
        paused = false;

        yield return new WaitForSeconds(buttonClickSound.clip.length);

        Application.Quit ();
    }


}
