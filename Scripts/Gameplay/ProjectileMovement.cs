using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	private float ShotForce;
	public Rigidbody RB;
	public int Damage;
	public bool EnemyProjectile = false;

	void Start ()
	{
		// Used to add the force behind the cannonballs, so they fire once they enter the scene. There is
		// deviation for the distance each one reaches.
		ShotForce = Random.Range(2000, 3000);
		RB = GetComponent<Rigidbody>();
		RB.AddForce (transform.right * ShotForce);
		Destroy (gameObject, 10);
	}
}
