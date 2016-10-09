using UnityEngine;
using System.Collections;

public class movingPlatformController : MonoBehaviour {

	//Starting Point of Platform
	private Vector3 posA;

	//Ending Point of Platform
	private Vector3 posB;

	//the next position the platform will move
	private Vector3 nextPos;

	public float speed;

	//The childPlatform transform
	public Transform childPlatform;

	//PositionB trasform
	public Transform transformPosB;
	// Use this for initialization
	void Start () {

	
		posA = childPlatform.localPosition;

		posB = transformPosB.localPosition;
		//Initializing the nextPos
		nextPos = posB;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	private void move()
	{
		childPlatform.localPosition = Vector3.MoveTowards (childPlatform.localPosition, nextPos, speed * Time.deltaTime);

		if (Vector3.Distance (childPlatform.localPosition, nextPos) <= 0.1)
			changeDistantion ();

	}

	private void changeDistantion()
	{
		nextPos = nextPos != posA ? posA : posB;
	}
}
