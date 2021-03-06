using UnityEngine;
using System.Collections;

public class ButtonNavigationTimeTrial : MonoBehaviour
{

	//private MusicManager MusicManager;
	public LevelManager LevelManager;
	private SoundManager SoundManager;
	public bool LevelButton;

	public int TimeRemaining = 1;
	private int TimeRemainingOriginal;
	public string levelName;

	// Use this for initialization
	void Start ()
	{
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
		SoundManager = GameObject.Find("Manager_Sound").GetComponent<SoundManager>();
		TimeRemainingOriginal = TimeRemaining;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void CountDown ()
	{
		TimeRemaining = TimeRemaining - 1;
		if (TimeRemaining <= 0)
		{
			SoundManager.MakeMenuClick ();
			LoadLevelButton(levelName);
			LevelManager.TimeTrial = true;

			CancelInvoke ("CountDown");
			TimeRemaining = TimeRemainingOriginal;
		}
	}

	public void LoadLevelButton(string levelName)
	{
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
			SoundManager.MakeMenuClick ();
			Application.Quit();
		}
		else if(LevelButton)
		{
			SoundManager.MakeMenuClick ();
			LevelManager.LevelScreen = true;
		}
		else
		{
			SoundManager.MakeMenuClick ();
			Application.LoadLevel (levelName);
		}
	}

	public void MusicSelector(int TrackNumber)
	{
	//	MusicManager.AudioSelector = TrackNumber;
	}

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