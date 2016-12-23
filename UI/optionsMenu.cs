using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class optionsMenu : MonoBehaviour {


    public Slider musicSlider;
    public GameObject mainMenuGameObject;
    public Dropdown resolutionDropDown;

    List<string> resolutionNames = new List<string>(){"640  x 480","800 x 600","1024 x 768","1152 x 864","1280 x 960"};


	// Use this for initialization
	void Start () {
	
        fillDropDown();
	}
	
	// Update is called once per frame
	void Update () {
	
        musicSlider.value = backgroundMusicController.volume;




	}

    public void sliderOnValueChanged(){
        //Debug.Log(musicSlider.value);
        backgroundMusicController.volume = musicSlider.value;
    
    }

    public  void goBackToMainMenu(){
  
        mainMenuGameObject.SetActive(true);
        gameObject.SetActive(false);

    
    }

    public void fillDropDown(){

        resolutionDropDown.AddOptions(resolutionNames);

    }

    public void dropDownOnValueChanged(int index){

        string selectedResolution = resolutionNames[index];
   
      
        int indexOfX = selectedResolution.IndexOf('x');

        int width = Int32.Parse((selectedResolution.Substring(0, indexOfX - 1)));
       
        int height = Int32.Parse(selectedResolution.Substring(indexOfX+1));
       
        Screen.SetResolution(width,height, true);
        //selectedSceneName = levelNames[index];
       // indexDropDown = index;
    }


}
