using UnityEngine;
using System.Collections;

public class heartController : MonoBehaviour {

    //Reference to collectSound game object's AudioSource component
    private GameObject collectSoundEffect;

	// Use this for initialization
	void Start () {

        //Find the collectSound game object with tag "collectSoundEffect"
        collectSoundEffect = GameObject.FindGameObjectWithTag("collectSoundEffect");
	
	}
	

    void OnCollisionEnter2D(Collision2D coll){

        //Add one health,play the collectSoundEffect and destroy this game object
        if (coll.gameObject.CompareTag("Player"))
        {
            collectSoundEffect.GetComponent<AudioSource>().Play();
            coll.gameObject.GetComponent<playerController>().addHealth();
            Destroy(gameObject);

        }
         

    }
}
