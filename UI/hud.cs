using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hud : MonoBehaviour {

	//the array of hearts images
	public Sprite[] heartSprites;

	//heart image
	public Image heartUI;

	//object of playerController
	private playerController player;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController> ();

	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Obj"+heartSprites);
		heartUI.sprite = heartSprites[player.currentHealth];

	}
}
