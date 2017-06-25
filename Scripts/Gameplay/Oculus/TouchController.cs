using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour
{
	public OVRInput.Controller Controller;
	
	// Update is called once per frame
	void Update ()
	{
		// Used for tracking between th Oculus Touch controllers and the attacked gameObjects, used
		// as the player's hands.
		transform.localPosition = OVRInput.GetLocalControllerPosition(Controller);
		transform.localRotation = OVRInput.GetLocalControllerRotation(Controller);
	}
}
