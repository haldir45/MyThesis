using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hud : MonoBehaviour {


	public Sprite[] heartSprites;

	public Image heartUI;

	//Reference to player game object's script component
	public playerController player;

	// Update is called once per frame
	void Update () {

      //Updating the heart Sprite
      heartUI.sprite = heartSprites[player.currentHealth];

	}


}
