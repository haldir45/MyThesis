using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class doorController : MonoBehaviour {


    //Reference to woodenDoorOpenSound game object's AudioSource component 
    public AudioSource woodenDoorOpenSource;

    //Reference to the canva's dialogue Manager
    public dialogueManager dialogueManagerOBJ;



    //Reference to this game object's Animator component 
	private Animator anim;
    //Dialogue message
    string messageBox = "Door is Locked!!!";
    //Reference to gameManager game object
	private gameManager gm;
  
    private bool hasKey;



	// Use this for initialization
	void Start () {

        //Reference to the GameManager Class
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<gameManager> ();

		anim = GetComponent<Animator> ();

        //Setting the open animation to false
		anim.SetBool ("open", false);
        //Player has not key
        hasKey = false;
	}

    void Update(){
      
        checkOpen();

    }

    //Checks if the player hit the open button
    void checkOpen(){
        if (Input.GetKey("e") && hasKey)
            anim.SetBool("open", true);
    }

	void OnTriggerStay2D(Collider2D col)
	{
 
        //Shows and changes the dialogue if player has key
        if (col.CompareTag ("Player")){
            if (col.GetComponent<playerController>().hasKey){
                messageBox = "[E] to Enter";
                hasKey = true;
            }

            dialogueManagerOBJ.ShowBox(messageBox);
           
        }
       
	}

	void OnTriggerExit2D(Collider2D col){
        
		if (col.CompareTag ("Player"))
			dialogueManagerOBJ.HideBox ();
		
	}


    //Loading the next Scene when the open animation will end
	void loadNextScene(){
		saveScore ();

        string name = SceneManager.GetActiveScene().name;
        string i = name.Substring(5);


        //If the current scene is Level10(the last) load the MainMenu
        //Else load the next scene
        if (SceneManager.GetActiveScene().name == "Level10")
            SceneManager.LoadScene("MainMenu");
        else
            SceneManager.LoadScene ("Level" + (int.Parse(i)+1));
        


       
	}

    //Plays the woodenOpenDoor's AudioSource when the open animations start playing
    public void playOpenDoorSound(){

        woodenDoorOpenSource.Play();
    }


    //Saves the playr's score
	void saveScore(){
        PlayerPrefs.SetInt ("Score"+SceneManager.GetActiveScene().name,gm.diamonds);
	}

}
