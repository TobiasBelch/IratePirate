using UnityEngine;
using System.Collections;

public class FortBehaviour : MonoBehaviour
{
	// Controlls Targetting
	public Transform Target;
	public float RotateSpeed = 36.0f;

	// Controls Firing
	public Transform Cannon;
	public GameObject CannonBall;
	private float NextFire;
	public float FireRate;

	// Controls Health
	public int Health = 10;

	// WHen the cannon is destroyed, the gameobject for the cannon is removed from the level.
	void Update ()
	{
		if (Cannon == null)
		{
			Destroy (gameObject);
		}
	}


	void OnTriggerStay (Collider other)
	{
		// When the player is detected: Detect the angle of the rotation needed, then turns graduly towards
		// the player; allowing the cannonballs to fire towards them.
		if (other.gameObject.tag == "Player")
		{
			{
				Vector3 TargetDir = Target.position - transform.position;
				float step = RotateSpeed * Time.deltaTime;
				Vector3 newDir = Vector3.RotateTowards (transform.forward, TargetDir, step, 0.0f);
				Debug.DrawRay (transform.position, newDir, Color.red);
				transform.rotation = Quaternion.LookRotation (newDir);	
			}

			// Controls the firing speed of the cannon.
			if (Time.time > NextFire)
			{
				Instantiate (CannonBall, Cannon.position, Cannon.rotation);
				NextFire = Time.time + FireRate;
			}
		}
	}
}
