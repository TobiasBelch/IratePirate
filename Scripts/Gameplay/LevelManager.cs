using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	public TextMesh LevelTimeText;
	public TextMesh ScoreText;
	public bool TimeTrial = false;
	public bool ArenaMode = false;

	public float LevelTime = 0;
	public int Score = 0;
	public int Kills = 0;
	public int ShotsFired = 0;

	public bool TimeStop = false;
	public bool LevelScreen = false;
	
	// Update is called once per frame
	void Update ()
	{
		// Used to control the time and score while the user is playing a level.
		if (LevelScreen)
		{
			LevelTimeText = GameObject.Find ("UI_Time").GetComponent<TextMesh>();
			ScoreText = GameObject.Find ("UI_Score").GetComponent<TextMesh> ();

			if (!TimeStop)
			{
				LevelTime = LevelTime + Time.deltaTime;
			}

			LevelTimeText.text = "Time: " + LevelTime.ToString ("#.00");
			ScoreText.text = "Score: " + Score;
		}
	}
}

