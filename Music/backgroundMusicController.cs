using UnityEngine;
using System.Collections;

public class backgroundMusicController : MonoBehaviour {

    //Volume of the background Audio
    public static float volume = 0.50f;



	// Update is called once per frame
	void Update () {
	
       //Updating the volume of the background Audio
        gameObject.GetComponent<AudioSource>().volume = volume;
	}

  
   
}
