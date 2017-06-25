using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Results : MonoBehaviour
{
	private LevelManager LevelManager;

	public Text LevelTimeText;
	public Text ScoreText;
	public Text KillsText;
	public Text ShotsFiredText;

	public float PercentCounter = 0;
	public float MainMenuDelay = 1;

	void Start ()
	{
		// Calls for the manager scripts in the manager prefab.
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
	}

	void Update ()
	{
		// collects the text values of the UI and, uses a percentage value, counts the score up and shows the
		// player their result.
		LevelTimeText = GameObject.Find("UI_Time").GetComponent<Text>();
		ScoreText = GameObject.Find("UI_Score").GetComponent<Text>();
		KillsText = GameObject.Find("UI_Kills").GetComponent<Text>();
		ShotsFiredText = GameObject.Find("UI_ShotsFired").GetComponent<Text>();

		LevelTimeText.text = "Time: " + ( LevelManager.LevelTime * ( PercentCounter / 100 )).ToString ("0.00");
		ScoreText.text = "Score: " + ( LevelManager.Score * ( PercentCounter / 100 )).ToString ("0.");
		KillsText.text = "Kills: " + ( LevelManager.Kills * ( PercentCounter / 100 )).ToString ("0.");
		ShotsFiredText.text = "Shots Fired: " + ( LevelManager.ShotsFired * ( PercentCounter / 100 )).ToString ("0.");
				 
		// Used to uncrease the percentage counter forthe score reveal.
		if (PercentCounter != 100)
		{
			PercentCounter = PercentCounter + 1;
		}
		if (PercentCounter == 100) 
		{
			LevelManager.LevelTime = 0;
			LevelManager.Score = 0;
			LevelManager.Kills = 0;
			LevelManager.ShotsFired = 0;
			Application.LoadLevel ("level Select");
		}
	}
}

