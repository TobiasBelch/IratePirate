using UnityEngine;
using System.Collections;

public class Surrender : MonoBehaviour {
	public bool DoingAction = false;
	public float timer = 1;

	public LevelManager LevelManager;

	void Start ()
	{
		// Calls for the manager scripts in the manager prefab.
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
	}

	// if hands are above head and not doing an action end level
	void Update () 
	{

		if (OVRInput.Get(OVRInput.Button.Any))
		{
			DoingAction = true;
			timer = 0;
		}
		else 
		{
			DoingAction = false;
		}

		if (gameObject.transform.localPosition.y > 0.5 && DoingAction == false)
			{
			timer = timer + Time.deltaTime;
			}
		if (timer > 3)
		{
			LevelManager.ShotsFired = LevelManager.ShotsFired / 4;
			LevelManager.LevelScreen = false;
			LevelManager.TimeStop = true;
			Application.LoadLevel ("Level 1 Complete");
		}	
	}
}
