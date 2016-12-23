using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour {


    public GameObject startMenuGameObject;
    public GameObject optionsMenuGameObject;
    public GameObject scoreMenuGameObject;

    public AudioSource buttonClickSound;


	void Start(){
		Time.timeScale = 1;
   

	}
	public void startMenu(){
	

        startMenuGameObject.SetActive(true);
        gameObject.SetActive(false);

	}

    public void optionsMenu(){

        optionsMenuGameObject.SetActive(true);
        gameObject.SetActive(false);

    }

    public void scoreMenu(){

        scoreMenuGameObject.SetActive(true);
        gameObject.SetActive(false);


    }
    public void Quit(){

        StartCoroutine(closeTheGame());

    }

    IEnumerator closeTheGame(){
        buttonClickSound.Play();
 

        yield return new WaitForSeconds(buttonClickSound.clip.length);

        Application.Quit ();
    }

  
}
