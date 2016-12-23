using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class optionsMenu : MonoBehaviour {

    //Reference to mainMenu game object
    public GameObject mainMenuGameObject;
    public Slider musicSlider;
    public Dropdown resolutionDropDown;

    //List of screen resolutions
    List<string> resolutionNames = new List<string>(){"640  x 480","800 x 600","1024 x 768","1152 x 864","1280 x 960"};


	// Use this for initialization
	void Start () {
	
        fillDropDown();
	}
	
	// Update is called once per frame
	void Update () {
        //Updating the background music volume
        musicSlider.value = backgroundMusicController.volume;
	}

    //Fill dropDown with screen resolution's names
    public void fillDropDown(){

        resolutionDropDown.AddOptions(resolutionNames);

    }

    //Updating the parameter volume of backgroundMusicController script
    public void sliderOnValueChanged(){
       
        backgroundMusicController.volume = musicSlider.value;
    
    }

   
    //Setting the screen resolution when the dropdown's selected value is changed
    public void dropDownOnValueChanged(int index){

        string selectedResolution = resolutionNames[index];
   
      
        int indexOfX = selectedResolution.IndexOf('x');

        int width = Int32.Parse((selectedResolution.Substring(0, indexOfX - 1)));
       
        int height = Int32.Parse(selectedResolution.Substring(indexOfX+1));
       
        Screen.SetResolution(width,height, true);

    }

    //Back to Main Menu
    public  void goBackToMainMenu(){

        mainMenuGameObject.SetActive(true);
        gameObject.SetActive(false);


    }


}
