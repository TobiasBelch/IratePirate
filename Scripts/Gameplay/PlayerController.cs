using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	//Used for Testing Purposes
	public TextMesh ShipHull;

	// Ship's movement speed and rotation speed.
	public float MoveSpeed = 8f;
	public float RotateSpeed = 8.0f;

	// Max Speed ,Min Speed
	public float MaxSpeed = 24;
	public float MinSpeed = 8;

	// Used to make the change in the ship's speed gradual.
	public float CurrentMoveSpeed = 8.0f;
	private float CurrentRotateSpeed = 8.0f;

	// Used for health.
	public int Health = 100;
	public float HealthRegen = 0.5f;
	public int HealthPotency = 1;
	public float NextHeal = 0;
	public float MaxHealCap = 50;

	// Bool Checks
	public bool Shooting;
	public GameObject Anchor;
	public bool grabbinganchor;

	// Hands
	public GameObject LeftHand;
	public GameObject RightHand;
	public bool grabbingWheelRight = true;
	public bool grabbingWheelLeft = true;

	// Managers
	public LevelManager LevelManager;
	private SoundManager SoundManager;

	// Wheel
	public GameObject Wheel;
	public float wheelturnnumber;

	//Sails 
	public GameObject LeftSail;
	public GameObject RightSail;
	public float SailNotches;
	private float notch1 = 8;
	private float notch2 = 11;
	private float notch3 = 14;
	private float notch4 = 17;
	private float notch5 = 20;
	private float notch6 = 24;
	public float SpeedChangeDelay = 1;

	// Sinking
	public float SinkingAmount = -5;
	public float dropamount = 0.1f;
	public float timer;

	void Start ()
	{
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
		SoundManager = GameObject.Find("Manager_Sound").GetComponent<SoundManager>();

		// Refences in the sails for the ship
		LeftSail = GameObject.Find ("SailLeft");
		RightSail = GameObject.Find ("SailRight");
	}

	void Update ()
	{
	// this was a test done for a player throwing an anchor to slow down the ship
	//	if (Anchor.transform.localPosition.y < 0.07 && !OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger) || !OVRInput.Get (OVRInput.Button.SecondaryIndexTrigger)) 
	//	{
	//		grabbinganchor = false;
	//		CurrentMoveSpeed = 0.1f;
	//		RotateSpeed = 8f;
	//		MoveSpeed = 0.1f;
	//		CurrentRotateSpeed = 8f;
	//	}
	//	else
	//	{
	//		if (CurrentMoveSpeed != 8 && MoveSpeed != 8 && RotateSpeed != 8 && CurrentRotateSpeed !=8) 
	//		{
	//			CurrentMoveSpeed = CurrentMoveSpeed + 1f;
	//			RotateSpeed = RotateSpeed + 1f;
	//			MoveSpeed = MoveSpeed + 1f;
	//			CurrentRotateSpeed = CurrentRotateSpeed + 1f;
	//		}
	//	}

		// Checks for player trying to grab
		wheelturnnumber = Wheel.transform.rotation.z;
		gameObject.transform.position = new Vector3 (transform.position.x, SinkingAmount, transform.position.z);

		transform.position += transform.forward * Time.deltaTime * MoveSpeed;


		// Used for calculating the hull's health.
		ShipHull.GetComponent<TextMesh>().text = "Hull: " + Health + "%";

		// Checks for the player shooting
		if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
		{
			Shooting = true;
		}
		if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
		{
			Shooting = true;
		}
		else 
		{
			Shooting = false;
		}

		// Controls speeding up the ship.
		if (MoveSpeed < CurrentMoveSpeed) 
		{
			MoveSpeed = MoveSpeed + 1;
		}

		if (MoveSpeed > CurrentMoveSpeed) 
		{
			MoveSpeed = MoveSpeed - 1;
		}

		if (RotateSpeed < CurrentRotateSpeed) 
		{
			RotateSpeed = RotateSpeed + 1;
		}

		if (RotateSpeed > CurrentRotateSpeed) 
		{
			RotateSpeed = RotateSpeed - 1;
		} 

		// was used for Controling speed of ship with 6 different "Gears",is current not used
		//Notch6
		if (LeftSail.transform.localPosition.y > -0.079 && !Shooting && CurrentMoveSpeed < notch6)
		{
			CurrentMoveSpeed = MaxSpeed;
			CurrentRotateSpeed = 1;
		}
		if  (RightSail.transform.localPosition.y > -0.079 && !Shooting && CurrentMoveSpeed < notch6)
		{
			CurrentMoveSpeed = MaxSpeed;
			CurrentRotateSpeed = 1;
		}
			
		//Notch5
		if (LeftSail.transform.localPosition.y > -0.082 && !Shooting && CurrentMoveSpeed < notch5)
		{
			CurrentMoveSpeed = 20;
			CurrentRotateSpeed = 2;
		}
		if  (RightSail.transform.localPosition.y > -0.082 && !Shooting && CurrentMoveSpeed < notch5)
		{
			CurrentMoveSpeed = 20;
			CurrentRotateSpeed = 2;
		}

		//Notch4
		if (LeftSail.transform.localPosition.y > -0.086 && !Shooting && CurrentMoveSpeed < notch4)
		{
			CurrentMoveSpeed = 17;
			CurrentRotateSpeed = 4;
		}
		if  (RightSail.transform.localPosition.y > -0.086 && !Shooting && CurrentMoveSpeed < notch4)
		{
			CurrentMoveSpeed = 17;
			CurrentRotateSpeed = 4;
		}

		//Notch3
		if (LeftSail.transform.localPosition.y > -0.089 && !Shooting && CurrentMoveSpeed < notch3)
		{
			CurrentMoveSpeed = 14;
			CurrentRotateSpeed = 6;
		}
		if  (RightSail.transform.localPosition.y > -0.089 && !Shooting && CurrentMoveSpeed < notch3)
		{
			CurrentMoveSpeed = 14;
			CurrentRotateSpeed = 6;
		}

		//Notch2
		if (LeftSail.transform.localPosition.y > -0.092 && !Shooting && CurrentMoveSpeed < notch2)
		{
			CurrentMoveSpeed = 11;
			CurrentRotateSpeed = 8;
		}
		if  (RightSail.transform.localPosition.y > -0.092 && !Shooting && CurrentMoveSpeed < notch2)
		{
			CurrentMoveSpeed = 11;
			CurrentRotateSpeed = 8;
		}
			

		// Controls slowing down the ship. / Notch1
		if (LeftSail.transform.localPosition.y < -0.093 && !Shooting && CurrentMoveSpeed > notch1)
		{
			CurrentMoveSpeed = MinSpeed;
			CurrentRotateSpeed = 8;
		}
		if (RightSail.transform.localPosition.y < -0.093 && !Shooting && CurrentMoveSpeed > notch1)
		{
			CurrentMoveSpeed = MinSpeed;
			CurrentRotateSpeed = 8;
		}



		//Controls Turning The Ship ,based on players hand location
		if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && RightHand.transform.localPosition.y > -0.6 && !grabbinganchor)
		{	
			transform.Rotate (Vector3.down * CurrentRotateSpeed * Time.deltaTime);
		}
		if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && RightHand.transform.localPosition.y < -0.2 && !grabbinganchor)
		{	
			transform.Rotate (Vector3.up * CurrentRotateSpeed* Time.deltaTime);
		}
		if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && RightHand.transform.localPosition.y < -0.01 && !grabbinganchor)
		{	
			transform.Rotate (Vector3.up * CurrentRotateSpeed*2 * Time.deltaTime);
		}
		if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && RightHand.transform.localPosition.y > -0.8 && !grabbinganchor)
		{	
			transform.Rotate (Vector3.down * CurrentRotateSpeed*2 * Time.deltaTime);
		}


		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && LeftHand.transform.localPosition.y < -0.6 && !grabbinganchor)
		{	
			transform.Rotate (Vector3.down * CurrentRotateSpeed * Time.deltaTime);
		}
		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && LeftHand.transform.localPosition.y > -0.2 && !grabbinganchor)
		{	
			transform.Rotate (Vector3.up * CurrentRotateSpeed * Time.deltaTime);
		}
		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && LeftHand.transform.localPosition.y > -0.01 && !grabbinganchor)
		{	
			transform.Rotate (Vector3.up * CurrentRotateSpeed*2 * Time.deltaTime);
		}
		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && LeftHand.transform.localPosition.y < -0.8 && !grabbinganchor)
		{	
			transform.Rotate (Vector3.down * CurrentRotateSpeed*2 * Time.deltaTime);
		}


		// Controls the repairing of the hull.

		if (Time.time > NextHeal && Health < MaxHealCap)
		{
			Health = Health + HealthPotency;
			SoundManager.MakeRepairAudio ();
			if (Health > 100)
			{
				Health = 100;

			}
			NextHeal = Time.time + HealthRegen;
		}

		if (Health <= 0) 
		{
			//controls ship sinking when at low health
			SinkingAmount = SinkingAmount - dropamount;
			Health = 0;
			if (SinkingAmount <= -10) 
			{	
				//when player is under water enter game over screen
				LevelManager.ShotsFired = LevelManager.ShotsFired / 4;
				LevelManager.LevelScreen = false;
				LevelManager.TimeStop = true;
				Application.LoadLevel ("Level 1 Complete");
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		// Used to detect if the player has taken damage.
		if (other.gameObject.tag == "CannonBall" && other.GetComponent<ProjectileMovement> ().EnemyProjectile) {
			int DamageTaken = other.GetComponent<ProjectileMovement> ().Damage;
			Health = Health - DamageTaken;
			SoundManager.MakeEnemyHitSound ();
			Destroy (other.gameObject, 0);
		}
	}

	void OnTriggerStay (Collider other)
	{
		// Used to check if the player is grabbing the wheel and the hand used.
		if (other.gameObject.tag == ("PlayerHand"))
		{
			if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && (OVRInput.Get (OVRInput.Button.SecondaryHandTrigger)))
			{
				grabbingWheelRight = true;
				grabbingWheelLeft = false;
			}
			else
			{
				grabbingWheelRight = false;	
			}

			if (OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger) && (OVRInput.Get (OVRInput.Button.PrimaryHandTrigger))) 
			{
				grabbingWheelLeft = true;
				grabbingWheelRight = false;
			}
			else
			{
				grabbingWheelLeft = false;
			}
		}
	}
}