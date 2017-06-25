using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public bool ArenaMode = false;
	public Transform SpawnLocation;
	public int random;
	public float Timer = 180;
	public float Spawns;
	public GameObject Enemy;

	public GameObject Ocean1;
	public GameObject Ocean2;
	public GameObject Ocean7;
	public GameObject Ocean8;
	
	// Randomly spawns in enemys up to a max limit
	void Update ()
	{
		Timer = Timer + 1;

		if (ArenaMode && Spawns <15 && Timer > 400)
		{
			Spawns = Spawns + 1;
			Instantiate (Enemy, SpawnLocation.position, SpawnLocation.rotation);
		}


		if (Timer > 400) 
		{
			Timer = 0;
			random = Random.Range (1, 4);
		}

		if (random == 1) 
		{
			SpawnLocation = Ocean1.transform;
		}
		if (random == 2) 
		{
			SpawnLocation = Ocean2.transform;
		}
		if (random == 3) 
		{
			SpawnLocation = Ocean7.transform;
		}
		if (random == 4) 
		{
			SpawnLocation = Ocean8.transform;
		}
	}
}
