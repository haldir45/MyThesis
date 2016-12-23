using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour {

    //Reference to startMenu,optionsMenu,scoreMenu game objects
    public GameObject startMenuGameObject;
    public GameObject optionsMenuGameObject;
    public GameObject scoreMenuGameObject;


    //Reference to buttonClickSound game object's AudioSource component
    public AudioSource buttonClickSoundEffect;


	void Start(){
        //Unpause Game
		Time.timeScale = 1;
	}

    //Open startMenu
	public void startMenu(){
        startMenuGameObject.SetActive(true);
        gameObject.SetActive(false);

	}

    //Open optionsMenu
    public void optionsMenu(){
     
        optionsMenuGameObject.SetActive(true);
        gameObject.SetActive(false);

    }

    //Open scoreMenu
    public void scoreMenu(){
        scoreMenuGameObject.SetActive(true);
        gameObject.SetActive(false);

    }

    //Close game
    public void Quit(){
      
        StartCoroutine(closeTheGame());

    }

    //The game closes after the buttonClickSoundeffect will end
    IEnumerator closeTheGame(){

        buttonClickSoundEffect.Play();
        yield return new WaitForSeconds(buttonClickSoundEffect.clip.length);
        Application.Quit ();
    }

  
}
