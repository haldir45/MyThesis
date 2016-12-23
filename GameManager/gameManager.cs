using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{

    //References to Canvas Text game object
	public Text diamondsT;
	public Text footUIT;
    public Text keyT;


	public int diamonds=0;
    public int healthLimitBoost;
    public int keys;




	// Use this for initialization
	void Start (){
        //Setting the healthLimitBoost to 0
        healthLimitBoost = diamonds;
    
	}
	
	// Update is called once per frame
	void Update (){

        updateUi();
        healthBoost();

	}

    void updateUi(){

        //Updating the diamonds and key Text 
        diamondsT.text = "X " + diamonds;
        keyT.text = "X " + keys;
    }

    void healthBoost(){
        //For every 10 diamonds and when the healthLimitBoost isn't equal to the current collected diamonds
        //The player gains 1 health back 
        if (diamonds % 10 == 0 && diamonds != healthLimitBoost){

            GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().addHealth();
            healthLimitBoost = diamonds;
        }
    }

    public void addDiamonds(){
        
        diamonds += 1;
    }


}

