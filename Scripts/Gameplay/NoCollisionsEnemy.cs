using UnityEngine;
using System.Collections;

public class NoCollisionsEnemy : MonoBehaviour
{
	public float Force = 1;
	public GameObject Parent;

	void OnTriggerStay(Collider Other)
	{
		// Uses a tag to check if the object is impassible. If so, the object going into this collider
		// is pushed back.
		if (Other.gameObject.tag == "Player")
		{
			Vector3 Direction = Other.transform.position - transform.position;
			Direction = -Direction.normalized;
			Parent.transform.position = transform.position + (Direction * Force);
		}
	}
}
