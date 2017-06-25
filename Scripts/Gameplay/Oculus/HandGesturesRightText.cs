using UnityEngine;
using System.Collections;

public class HandGesturesRightText : MonoBehaviour
{
	public TextMesh Text;
	
	// Update is called once per frame
	void Update ()
	{
		// Used to change the gesture of the hands when a certain combonation of buttons are pressed.
		if (OVRInput.Get (OVRInput.Button.SecondaryIndexTrigger))
		{
			Text.text = "This Is Your Fist";

		}
		else if (OVRInput.Get (OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get (OVRInput.Button.SecondaryIndexTrigger))
		{
			Text.text = "This Is Your Pointing Hand";
		}
		else
		{
			Text.text = "This Is Your Base Hand";
		}
	}
}