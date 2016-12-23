using UnityEngine;
using System.Collections;

public class tutorialDialogueBox : MonoBehaviour {

    //Reference to dialogueManager game object
	public dialogueManager dialogueManagerOBJ;

    //Dialogue Message
	public string dialogue;



	void OnTriggerStay2D(Collider2D other){
		
        //Show dialogueBox
		if (other.CompareTag ("Player")) {
			
			dialogueManagerOBJ.ShowBox (dialogue);
            StartCoroutine(closeShowBox());
		}
	}

    //After 3 sec destroy the dialogueManager game object
    IEnumerator closeShowBox(){

        yield return new WaitForSeconds(3);
        dialogueManagerOBJ.HideBox();
        Destroy(gameObject);


    }

	


}
