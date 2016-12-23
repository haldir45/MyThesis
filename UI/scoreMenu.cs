using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class scoreMenu : MonoBehaviour {

    //Reference to mainMenu game object
    public GameObject mainMenuGameObject;

    //List of level scores
    public List<Text> scoreTextList = new List<Text>();


	// Use this for initialization
	void Start () {
      //  PlayerPrefs.DeleteAll();
        for (int i = 0; i < scoreTextList.Capacity; i++){
            //Get the score and print it to canvas text
            string scoreS = PlayerPrefs.GetInt("ScoreLevel" + (i + 1)).ToString() +scoreTextList[i].text;
            scoreTextList[i].text = scoreS;
        }

	}

    //Back to Main Menu
    public  void goBackToMainMenu(){

        mainMenuGameObject.SetActive(true);
        gameObject.SetActive(false);


    }
   
}
