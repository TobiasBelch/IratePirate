using UnityEngine;
using System.Collections;

public class KillsObjective : MonoBehaviour
{
	public LevelManager LevelManager;

	public int KillTarget;

	void Start ()
	{
		// Calls for the manager scripts in the manager prefab.
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Used to transitionto the level complete screen once the objective has been complete. Since the
		// cannons fire in fours, the shots fired is divided by 4 to get the true number of shots fired.
		if (LevelManager.Kills >= KillTarget)
		{
			LevelManager.ShotsFired = LevelManager.ShotsFired / 4;
			LevelManager.LevelScreen = false;
			LevelManager.TimeStop = true;
			Application.LoadLevel ("Level 1 Complete");
		}
	}
}
