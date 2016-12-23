using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class scoreMenu : MonoBehaviour {


    public GameObject mainMenuGameObject;
    public List<Text> scoreTextList = new List<Text>();
	// Use this for initialization
	void Start () {
      //  PlayerPrefs.DeleteAll();
   
        for (int i = 0; i < scoreTextList.Capacity; i++){
          
         
            string scoreS = PlayerPrefs.GetInt("ScoreLevel" + (i + 1)).ToString() +scoreTextList[i].text;
            scoreTextList[i].text = scoreS;
        }

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public  void goBackToMainMenu(){

        mainMenuGameObject.SetActive(true);
        gameObject.SetActive(false);


    }
   
}
