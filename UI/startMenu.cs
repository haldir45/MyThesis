using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class startMenu : MonoBehaviour {

 

    public Dropdown sceneDropDown;
    public GameObject mainMenuGameObject;

    List<string> levelNames = new List<string>(){"Select a Level ","Level1","Level2","Level3",
        "Level4","Level5","Level6","Level7","Level8"};

    string selectedSceneName;
    int indexDropDown;




	// Use this for initialization
	void Start () {

        fillDropDown();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
        
    void fillDropDown(){
        sceneDropDown.AddOptions(levelNames);
    }
   
    public void dropDownOnValueChanged(int index){

        selectedSceneName = levelNames[index];
        indexDropDown = index;
    }

    public void startScene(){


        if (indexDropDown != 0)
        {
           // backgroundMusicController.audioBegin = false;
           //backgroundMusicObject.GetComponent<backgroundMusicController>().audioBegin = false;
         //   Destroy(backgroundMusicObject);
            SceneManager.LoadScene(selectedSceneName);
        }


    }

    public  void goBackToMainMenu(){
        mainMenuGameObject.SetActive(true);
        gameObject.SetActive(false);
    }


}
