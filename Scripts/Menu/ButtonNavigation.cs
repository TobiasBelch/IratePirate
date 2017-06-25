using UnityEngine;
using System.Collections;

public class ButtonNavigation : MonoBehaviour
{
	public LevelManager LevelManager;
	private SoundManager SoundManager;

	private int TimeRemaining = 1;
	private int TimeRemainingOriginal;

	public bool LevelButton;
	public bool TimeTrialButton;
	public string levelName;

	// Use this for initialization
	void Start ()
	{
		// Calls for the manager scripts in the manager prefab.
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
		SoundManager = GameObject.Find("Manager_Sound").GetComponent<SoundManager>();
		TimeRemainingOriginal = TimeRemaining;
	}

	void CountDown ()
	{
		// Used to count down a timer when the player looks at a button.
		TimeRemaining = TimeRemaining - 1;
		if (TimeRemaining <= 0)
		{
			SoundManager.MakeMenuClick ();
			LoadLevelButton(levelName);

			CancelInvoke ("CountDown");
			TimeRemaining = TimeRemainingOriginal;
		}
	}

	// used to transition between levels. Certain levels require values to be reset, or certain
	// fuctions to be executed.

	public void LoadLevelButton(string levelName)
	{
		SoundManager.MakeMenuClick ();

		if (levelName == "Level Select")
		{
			LevelManager.LevelTime = 0;
			LevelManager.Score = 0;
			LevelManager.Kills = 0;
			LevelManager.ShotsFired = 0;
			LevelManager.TimeStop = false;
			Application.LoadLevel (levelName);
		}
		else if (levelName == "Quit")
		{
			Application.Quit();
		}
		else
		{
			Application.LoadLevel (levelName);
		}

		// Used to

		if(LevelButton)
		{
			LevelManager.LevelScreen = true;
		}

		if(TimeTrialButton)
		{
			LevelManager.TimeTrial = true;
		}
	}

	// Used to execute the countdown when a player looks at a button, or cancel the countdown
	// when the player looks away.

	public void MouseOver()
	{
		InvokeRepeating ("CountDown", 1, 1);
	}

	public void MouseOut()
	{
		CancelInvoke ("CountDown");
		TimeRemaining = TimeRemainingOriginal;
	}
}