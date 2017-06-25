using UnityEngine;
using System.Collections;

public class ShipCannonBehaviour : MonoBehaviour
{
	// Controlls Targetting
	public Transform Target;
	public float RotateSpeed = 36.0f;

	// Controls Firing
	public Transform Cannon;
	public GameObject CannonBall;
	private float NextFire;
	public float FireRate;
		

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			// Used for the cannon's firing rate.
			if (Time.time > NextFire)
			{
				Instantiate (CannonBall, Cannon.position, Cannon.rotation);
				NextFire = Time.time + FireRate;
			}
		}
	}
}