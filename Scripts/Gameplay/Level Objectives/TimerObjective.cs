using UnityEngine;
using System.Collections;

public class TimerObjective : MonoBehaviour
{
	public LevelManager LevelManager;

	public int TimerTarget = 10;
	public bool TimeTrial = false;

	// Use this for initialization
	void Start ()
	{
		// Calls for the manager scripts in the manager prefab.
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Used to check if there is a time trail in the level, then records the quickest time when the player
		// completes the level.

		TimeTrial = LevelManager.TimeTrial;

		if (LevelManager.LevelTime >= TimerTarget && TimeTrial)
		{
			LevelManager.ShotsFired = LevelManager.ShotsFired / 4;
			LevelManager.LevelScreen = false;
			LevelManager.TimeStop = true;
			Application.LoadLevel ("Level 1 Complete");
		}
	}
}
