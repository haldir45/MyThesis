using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

    //Reference to dialogueBox game object
	public GameObject dialogueBox;


	public Text dialogueText;

	public bool dialogActive;


	public void ShowBox(string dialogue){
		dialogActive = true;

		dialogueBox.SetActive (true);

		dialogueText.text = dialogue;
	}

	public void HideBox(){
		dialogActive = false;
		dialogueBox.SetActive (false);

	}
}
