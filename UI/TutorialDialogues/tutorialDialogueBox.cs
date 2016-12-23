using UnityEngine;
using System.Collections;

public class tutorialDialogueBox : MonoBehaviour {

	public dialogueManager dialogueManagerOBJ;


	public string dialogue;



	void OnTriggerStay2D(Collider2D other){
		
		if (other.CompareTag ("Player")) {
			
			dialogueManagerOBJ.ShowBox (dialogue);
            StartCoroutine(closeShowBox());
		}
	}

    IEnumerator closeShowBox(){

        yield return new WaitForSeconds(3);
        dialogueManagerOBJ.HideBox();
        Destroy(gameObject);


    }

	


}
