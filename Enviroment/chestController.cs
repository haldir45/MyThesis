using UnityEngine;
using System.Collections;

public class chestController : MonoBehaviour {

    //Reference to chestOpenSound game object's AudioSource component
    public AudioSource chestOpenSound;
    //Reference to the canva's dialogue Manager
    public dialogueManager dialogueManagerOBJ;



    //Reference to this game object's Animator component 
    private Animator anim;
    //Reference to gameManager game object
    private gameManager gm;

    private bool open;
   
	// Use this for initialization
	void Start () {

    
        anim = GetComponent<Animator> ();

        //Reference to the GameManager Class
        gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<gameManager> ();

       
        //Setting the open animation to false
        anim.SetBool("open", false);
        open = false;
	}
	
	// Update is called once per frame
	void Update () {


        checkOpen();
 
       
	}

    //Checks if the player hit the open button
    void checkOpen(){
        //Setting the open animation to true,adding 5 diamonds and play chestOpenSound's AudioSource
        if (Input.GetKeyDown("e") & (!open)){
            chestOpenSound.Play();
            gm.diamonds += 5;
            open = true;
            anim.SetBool("open", true);
        }
    }


    void OnTriggerStay2D(Collider2D col){
            //Show the dialogue
            if (col.CompareTag("Player")) 
                dialogueManagerOBJ.ShowBox("[E] to Open");

    }

    void OnTriggerExit2D(Collider2D col){

        //Hide dialogue when player leaves
        if (col.CompareTag ("Player")) 
            dialogueManagerOBJ.HideBox ();
        
    }

    void closeChest(){

        //Setting the open animation to false,Hide dialogue and destroy the chest after 2 secs
        anim.SetBool("open", false);
        dialogueManagerOBJ.HideBox ();
        Destroy(gameObject, 2);
      
    }

 

}
