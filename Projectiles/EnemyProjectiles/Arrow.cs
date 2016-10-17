using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player") )
		{
			col.GetComponent<playerController>().damage(1);

				Destroy(gameObject);
		}
	}
}
