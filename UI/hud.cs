using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hud : MonoBehaviour {

	//the array of hearts images
	public Sprite[] heartSprites;

	//heart image
	public Image heartUI;

	//object of playerController
	public playerController player;



	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Obj"+heartSprites);
		heartUI.sprite = heartSprites[player.currentHealth];

	}
}
