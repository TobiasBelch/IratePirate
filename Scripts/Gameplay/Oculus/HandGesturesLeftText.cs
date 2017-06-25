using UnityEngine;
using System.Collections;

public class HandGesturesLeftText : MonoBehaviour
{
	public TextMesh Text;
	
	// Update is called once per frame
	void Update ()
	{
		// Used to change the gesture of the hands when a certain combonation of buttons are pressed.
		if (OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger)) 
		{
			Text.text = "This Is Your Fist";
		}
		else if (OVRInput.Get (OVRInput.Button.PrimaryHandTrigger) && !OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger))
		{
			Text.text = "This Is Your Pointing Hand";
		}
		else
		{
			Text.text = "This Is Your Base Hand";
		}
	}
}