using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutOfBounds : MonoBehaviour 
{

	public bool OutOfBoundsCheck;
	public TextMesh OutOfBoundsText;
	public float OutOfBoundsTimer;
	public TextMesh OutOfBoundsTimerText;

	private LevelManager LevelManager;

	void Start ()
	{
		// Calls for the manager scripts in the manager prefab.
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
	}

	void Update ()
	{
		// When the player leaves the colission box: A timer is triggered, counting down until it hits 0. The counter
		// is reset and stopped if they return back into the collider.
		if (OutOfBoundsCheck)
		{
			OutOfBoundsText.GetComponent<TextMesh> ().text = "Out of Bounds!";
			OutOfBoundsTimer = OutOfBoundsTimer - Time.deltaTime;
			OutOfBoundsTimerText.GetComponent<TextMesh> ().text = OutOfBoundsTimer.ToString ("#.00");
			if (OutOfBoundsTimer <= 0)
			{
				LevelManager.ShotsFired = LevelManager.ShotsFired / 4;
				LevelManager.LevelScreen = false;
				LevelManager.TimeStop = true;
				Application.LoadLevel ("Level 1 Complete");
			}
		}
		else
		{
			OutOfBoundsText.GetComponent<TextMesh> ().text = "";
			OutOfBoundsTimer = 20;
			OutOfBoundsTimerText.GetComponent<TextMesh> ().text = "";
		}
	}

	// Used to check if the player had left the collider or not.
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Player"))
		{
			OutOfBoundsCheck = false;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == ("Player"))
		{
			OutOfBoundsCheck = true;
		}
	}
}
