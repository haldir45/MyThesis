using UnityEngine;
using System.Collections;

public class sawTrapController : MonoBehaviour {

    public float speed;

    //The childPlatform transform
    public Transform childPlatform;

    //PositionB trasform
    public Transform transformPosB;


	//Starting Point of Platform
	private Vector3 posA;

	//Ending Point of Platform
	private Vector3 posB;

	//the next position the platform will move
	private Vector3 nextPos;



	// Use this for initialization
	void Start () {


        //Initializing the nextPos,posA,posB
		posA = childPlatform.localPosition;

		posB = transformPosB.localPosition;
		
        nextPos = posB;

	}
	
	// Update is called once per frame
	void Update () {
		move ();

    }
	private void move(){
        //Moving the sawTrap to next position
		childPlatform.localPosition = Vector3.MoveTowards (childPlatform.localPosition, nextPos, speed * Time.deltaTime);
   
        //When the platform reach the nextPos it changes destination
		if (Vector3.Distance (childPlatform.localPosition, nextPos) <= 0.1)
			changeDistantion ();
	}

    //Changing the nextPos 
	private void changeDistantion(){
		nextPos = nextPos != posA ? posA : posB;
	}


}
