using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;
	public AudioSource Audio;

	public AudioClip CannonFireSound;
	public AudioClip CannonBallHittingWater;
	public AudioClip EnemyHitSound1;
	public AudioClip EnemyHitSound2;
	public AudioClip EnemyHitSound3;
	public AudioClip MenuClick;
	public AudioClip RepairAudio;

	void Awake()
	{
		// Awakens the script, so it allows sounds to play.
		Audio = GetComponent<AudioSource>();

		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}

	// Each void will play a specific sound to play when the yare called.
	public void MakeCanonFireSound()
	{
		MakeSound(CannonFireSound);
	}

	public void MakeEnemyHitSound()
	{
		int RandomSound = Random.Range(1, 3);
		if (RandomSound == 1)
		{
			MakeSound(EnemyHitSound1);
		}
		else if (RandomSound == 2)
		{
			MakeSound(EnemyHitSound2);
		}
		else if (RandomSound == 3)
		{
			MakeSound(EnemyHitSound3);
		}

	}

	public void MakeMenuClick()
	{
		MakeSound (MenuClick);
	}

	public void MakeRepairAudio()
	{
		MakeSound (RepairAudio);
	}

	public void MakeCannonBallHittingWater()
	{
		MakeSound (CannonBallHittingWater);
	}

	// Aloows the sounds above to be played.
	private void MakeSound(AudioClip originalClip)
	{
		// As it is not 3D, position doesn't matter.
		GetComponent<AudioSource>().volume = 1.0f;
		GetComponent<AudioSource>().spatialBlend = 0.0f;
		GetComponent<AudioSource>().panStereo = 0;
		Audio.PlayOneShot(originalClip);
	}
}