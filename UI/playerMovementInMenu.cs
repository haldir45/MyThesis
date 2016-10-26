using UnityEngine;
using System.Collections;

public class playerMovementInMenu : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.CompareTag ("movingPlatform"))
			transform.parent = col.transform;
	}
}
