using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class startMenu : MonoBehaviour {

 
    //Reference to mainMenu and dropDown List
    public Dropdown sceneDropDown;
    public GameObject mainMenuGameObject;


    //List with all the level names
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
        
    //Fill the dropDown with the level names
    void fillDropDown(){
        sceneDropDown.AddOptions(levelNames);
    }
   
    //When the value is changed store the index 
    public void dropDownOnValueChanged(int index){

        selectedSceneName = levelNames[index];
        indexDropDown = index;
    }

    //Start the selected scene from the dropDown
    public void startScene(){

        if (indexDropDown != 0){

            SceneManager.LoadScene(selectedSceneName);
        }

    }


    //Back to Main Menu
    public  void goBackToMainMenu(){
        mainMenuGameObject.SetActive(true);
        gameObject.SetActive(false);
    }


}
