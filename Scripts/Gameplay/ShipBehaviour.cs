using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour
{
	public Transform Target;
	public bool SpottedTarget = false;
	public float MoveSpeed = 8.0f;
	public float RotateSpeed = 8.0f;
	public float SpottedRotateSpeed = 0.25f;

	public int Health;
	
	// Update is called once per frame
	void Update ()
	{
		// Used for assigning the player as the enemy's tagrte, then makes them rotate in an area if they haven't been
		// detected.
		transform.position += transform.forward * Time.deltaTime * MoveSpeed;

		if (!SpottedTarget)
		{
			transform.Rotate (Vector3.up * RotateSpeed * Time.deltaTime);
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			// Used for the enemies to rotate towards the player when they enter their detection sphere.
			SpottedTarget = true;
			Vector3 TargetDir = Target.position - transform.position;
			float step = SpottedRotateSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, TargetDir, step, 0.0f);
			Debug.DrawRay (transform.position, newDir, Color.red);
			transform.rotation = Quaternion.LookRotation (newDir);
		}
	}

	void OnTriggerExit (Collider other)
	{
		// Used so the enemies lose their tagret if they leave their detection sphere.
		if (other.gameObject.tag == "Player")
		{
			SpottedTarget = false;
		}
	}
}
