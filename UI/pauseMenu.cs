using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class pauseMenu : MonoBehaviour {

   
    //Reference to pauseUi,pause,options game object
	public GameObject pauseUI;

    public GameObject pauseGameObject;

    public GameObject  optionsGameObject;

    //Reference to backgroundMusic game object's AudioSource component
    public AudioSource backgroundMusic;

	private bool paused = false;



    public AudioSource buttonClickSoundEffect;


	// Use this for initialization
	void Start () {
 
		pauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
        checkPause();

        //If button pause was clicked pause game and open pauseUI 
        //else unpause game and close pauseUi
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

    //Checking if the pause button was clicked
    void checkPause(){
        if (Input.GetButtonDown ("Pause")) {
            paused = !paused;

            pauseGameObject.SetActive(true);
            optionsGameObject.SetActive(false);
        }
    }
    //Unpause Game
	public void Resume(){

		paused = false;

	}

    //Open options menu
    public void Options(){


        pauseGameObject.SetActive(false);
        optionsGameObject.SetActive(true);

    }

    //Restart level
	public void Restart(){
      
        StartCoroutine(reloadLevel());

	}

    //Reload the level after the buttonClickSoundEffect is ended
    IEnumerator reloadLevel(){
        buttonClickSoundEffect.Play();
        paused = false;
        yield return new WaitForSeconds(buttonClickSoundEffect.clip.length);
       

       SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //Load main menu
    public void mainMenu(){

        StartCoroutine(loadMainMenu());
       
    }

    //Load main menu level after the buttonClickSoundEffect is ended
    IEnumerator loadMainMenu(){
        buttonClickSoundEffect.Play();
        paused = false;

        yield return new WaitForSeconds(buttonClickSoundEffect.clip.length);

        SceneManager.LoadScene("MainMenu");

    }

    //Close game
    public void Quit(){

        StartCoroutine(closeTheGame());

    }

    //The game closes after the buttonClickSoundeffect will end
    IEnumerator closeTheGame(){
        buttonClickSoundEffect.Play();
        paused = false;

        yield return new WaitForSeconds(buttonClickSoundEffect.clip.length);

        Application.Quit ();
    }


}
