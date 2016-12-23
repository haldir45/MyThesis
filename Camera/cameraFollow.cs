using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	//Velocity of camera  
	private Vector2 velocity;

    //The min and max position of camera
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    //Smooth parameters for the X and Y Axis
    public float smoothTimeY;
	public float smoothTimeX;

	//Player
	public GameObject player;

    //Bounds enable the min and max positioning of the camera
	public bool bounds;


	// Use this for initialization
	void Start (){

        //Find the player game object with tag "Player"
		player = GameObject.FindGameObjectWithTag ("Player");

	
	}
	

	void FixedUpdate (){
		//Camera follows the player after smoothTimeX and smoothTimeY
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        //Update the position of camera
		transform.position = new Vector3 (posX, posY, transform.position.z);


		//Setting bounds for the Camera
		if (bounds){
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
		}

	}


}
