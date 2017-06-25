using UnityEngine;
using System.Collections;

public class HandGesturesRight : MonoBehaviour
{
	public GameObject HandFlat;
	public GameObject HandFist;
	public GameObject HandPoint;
	
	// Update is called once per frame
	void Update ()
	{
		// Used to change the gesture of the hands when a certain combonation of buttons are pressed.
		if (OVRInput.Get (OVRInput.Button.SecondaryIndexTrigger))
		{
			HandFist.SetActive(true);
			HandPoint.SetActive (false);
			HandFlat.SetActive(false);
		}
		else if (OVRInput.Get (OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get (OVRInput.Button.SecondaryIndexTrigger))
		{
			HandFist.SetActive(false);
			HandPoint.SetActive (true);
			HandFlat.SetActive(false);
		}
		else
		{
			HandFist.SetActive(false);
			HandPoint.SetActive (false);
			HandFlat.SetActive(true);
		}
	}
}