using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawSoundController : MonoBehaviour {

    //Reference to player game object's Transform component
    public Transform playerGameObject;


    //Distance between the player and the saw
    private float distance;

    //Reference to sawSound game object's AudioSource component 
    private AudioSource sawSoundEffect;

	// Use this for initialization
	void Start () {
        sawSoundEffect=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        checkDistance();
	}

    //Checking the distance between the player and the saw

    void checkDistance(){

        distance = Vector3.Distance(playerGameObject.transform.position, transform.position);

        //If the distance < 6 turn the spatialBlend to 2D else to 3D
        if (distance < 6)
            sawSoundEffect.spatialBlend = 0;

        else
            sawSoundEffect.spatialBlend += 0.01f;
    }

}
