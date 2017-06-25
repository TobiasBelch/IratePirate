using UnityEngine;
using System.Collections;

public class NoColission : MonoBehaviour
{
	public float Force = 1;

	void OnTriggerStay(Collider Other)
	{
		// Uses a tag to check if the object is impassible. If so, the object going into this collider
		// is pushed back.
		if (Other.gameObject.tag == "Impassible")
		{
			Vector3 Direction = Other.transform.position - transform.position;
			Direction = -Direction.normalized;
			transform.position = transform.position + (Direction * Force);
		}
	}
}
