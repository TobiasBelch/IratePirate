using UnityEngine;
using System.Collections;

public class NPCShipBehaviour : MonoBehaviour
{
	public Transform Target;
	public int RadomMovement;
	public float MovementTimer = 190;
	public bool SpottedTarget = false;
	public float MoveSpeed = 30.0f;
	public float RotateSpeed = 15.0f;
	public float SpottedRotateSpeed = 0.25f;

	public int Health = 100;

	// Random locations for the ship to visit
	public GameObject Ocean1;
	public GameObject Ocean2;
	public GameObject Ocean3;
	public GameObject Ocean4;
	public GameObject Ocean5;
	public GameObject Ocean6;
	public GameObject Ocean7;
	public GameObject Ocean8;
	public GameObject Player;
	
	// after a set time the ship gets a new location to move to
	void Update ()
	{
		MovementTimer = MovementTimer + 1;
		if (MovementTimer > 200) 
		{
			MovementTimer = 0;
			RadomMovement = Random.Range (1, 9);
		}

		if (RadomMovement == 1) 
		{
			Target = Ocean1.transform;
		}
		if (RadomMovement == 2) 
		{
			Target = Ocean2.transform;
		}
		if (RadomMovement == 3) 
		{
			Target = Ocean3.transform;
		}
		if (RadomMovement == 4) 
		{
			Target = Ocean4.transform;
		}
		if (RadomMovement == 5) 
		{
			Target = Ocean5.transform;
		}if (RadomMovement == 6) 
		{
			Target = Ocean6.transform;
		}if (RadomMovement == 7) 
		{
			Target = Ocean7.transform;
		}
		if (RadomMovement == 8) 
		{
			Target = Ocean8.transform;
		}
		// go after the player if they have attacked you if not find a new target
		if (RadomMovement == 9 && Health <100) 
		{
			Target = Player.transform;
		}
		if (RadomMovement == 9 && Health >95) 
		{			
			MovementTimer = 190;
		}
			
		// makes the ships move towards the target
	transform.position += transform.forward * Time.deltaTime * MoveSpeed;

		if (!SpottedTarget)
		{
			transform.Rotate (Vector3.up * RotateSpeed * Time.deltaTime);
		}
	}

		// if the player has attacked attack back
		void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player" && Health <100)
		{
			SpottedTarget = true;
			Vector3 TargetDir = Target.position - transform.position;
			float step = SpottedRotateSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, TargetDir, step, 0.0f);
			Debug.DrawRay (transform.position, newDir, Color.red);
			transform.rotation = Quaternion.LookRotation (newDir);

		}
	}

	// if you cant find player dont shoot
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			SpottedTarget = false;
		}
	}
}
