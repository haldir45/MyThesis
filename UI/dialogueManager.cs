using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

	public GameObject dialogueBox;
	public Text dialogueText;

	public bool dialogActive;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
			
	
	}

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
