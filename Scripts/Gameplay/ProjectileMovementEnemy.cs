using UnityEngine;
using System.Collections;

public class ProjectileMovementEnemy : MonoBehaviour {

	private float ShotForceHigh = 5000;
	private float ShotForceLow = 1000;
	public Rigidbody RB;

	// Use this for initialization
	void Start ()
	{
		// Used to add the force behind the cannonballs, so they fire once they enter the scene. There is
		// deviation for the distance each one reaches.
		RB = GetComponent<Rigidbody>();
		RB.AddForce (transform.right * Random.Range(ShotForceLow, ShotForceHigh));
		Destroy (gameObject, 10);
	}
}
