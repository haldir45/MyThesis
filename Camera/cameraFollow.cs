﻿using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	//Velocity of camera and smooth parameters for the X and Y Axis
	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	//Player
	public GameObject player;

    //bounds
	public bool bounds;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	

	void FixedUpdate () 
	{
		//Following the player and Smoothing the follow
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);


		//Setting bounds for the Camera
		if (bounds) 
		{
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
		}

	}
}
