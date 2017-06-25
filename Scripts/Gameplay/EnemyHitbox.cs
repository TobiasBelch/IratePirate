using UnityEngine;
using System.Collections;

public class EnemyHitbox : MonoBehaviour
{
	private LevelManager LevelManager;

	public int Health = 50;
	public GameObject HealthObject;

	// Sinking
	public float SinkingAmount = -5;
	public float dropamount = 0.5f;


	private SoundManager SoundManager;

	void Start ()
	{
		// Calls for the manager scripts in the manager prefab.
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
		SoundManager = GameObject.Find("Manager_Sound").GetComponent<SoundManager>();
	}

	void Update ()
	{
		//HealthObject.transform.position = new Vector3 (transform.position.x, SinkingAmount, transform.position.z);
		// When the enemy object is destroyed. Adds the kill score and kill to the counters, then
		// removes the object from the level.
		if (Health <= 0)
		{
			SinkingAmount = SinkingAmount - dropamount;
			if (SinkingAmount < -10) 
			{
				LevelManager.Score = LevelManager.Score + 100;
				LevelManager.Kills = LevelManager.Kills + 1;
				Destroy (HealthObject);
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		// Used to detect if a cannonball hit an enemy, then adds the score when it is true.
		if (other.gameObject.tag == "CannonBall" && !other.GetComponent<ProjectileMovement>().EnemyProjectile && Health > 0)
		{
			int DamageTaken = other.GetComponent<ProjectileMovement>().Damage;
			Health = Health - DamageTaken;
			LevelManager.Score = LevelManager.Score + 10;
			Destroy(other.gameObject, 0);
			SoundManager.MakeEnemyHitSound();
		}
	}
}
