using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootCannonLeft: MonoBehaviour 
{
	public Transform Cannon;
	public GameObject CannonBall;
	public LevelManager LevelManager;
	public bool Aiming;

	public float FireRate = 0.0f;
	public float NextFire = 2.0f;

	public bool Grabbing = false;
	public float ReloadDisplay;
	public float ReloadPercent;
	public TextMesh ReloadText;

	public GameObject LeftHand;
	public GameObject Crosshair;

	private SoundManager SoundManager;


	// Use this for initialization
	void Start ()
	{
		LevelManager = GameObject.Find("Manager_Level").GetComponent<LevelManager>();
		SoundManager = GameObject.Find("Manager_Sound").GetComponent<SoundManager>();
		LeftHand = GameObject.Find ("OVRLeftHand");
	}

	// when you are pressing down the aiming button and set up for firing
	void Aim ()
	{
		Aiming = true;

		ReloadPercent = ReloadPercent + Time.deltaTime;

		if (ReloadPercent > FireRate) 
		{
			ReloadDisplay = 100;
		} 
		else 
		{
			ReloadDisplay = (ReloadPercent / FireRate) * 100;
		}
		ReloadText.text = ReloadDisplay.ToString ("0.") + "%";
	}

	// when you are done aiming fire the cannons 
	void Fire ()
	{
		Aiming = false;
		if (OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger)) 
		{
			Grabbing = true;
		} 
		else
		{
			Grabbing = false;
		}

		if (Grabbing == false)
		{
			if (Time.time > NextFire) 
			{
				Instantiate (CannonBall, Cannon.position, Cannon.rotation);
				LevelManager.ShotsFired = LevelManager.ShotsFired + 1;
				ReloadPercent = 0;
				NextFire = Time.time + FireRate;
				SoundManager.MakeCanonFireSound ();
				ReloadDisplay = 0;
			}
		}
	}


	// checks for if the player is firing or aiming
	void Update ()
	{
		if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)) Aim ();

			if(!OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
		{
			if (ReloadDisplay == 100)
			{
				Fire ();
				ReloadText.text = ReloadDisplay.ToString ("0.") + "%";
			}
			else
			{
				Aiming = false;
				ReloadPercent = 0;
				ReloadDisplay = 0;
				ReloadText.text = ReloadDisplay.ToString ("0.") + "%";
			}
		}

		if (Aiming)
		{
			Crosshair.SetActive(true);
		}
		else
		{
			Crosshair.SetActive(false);
		}
	}
}



