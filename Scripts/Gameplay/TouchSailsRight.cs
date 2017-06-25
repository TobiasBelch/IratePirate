using UnityEngine;
using System.Collections;

public class TouchSailsRight : MonoBehaviour 
	{
	public bool GrabbingSailLeft = false;
	public bool GrabbingSailRight = false;
	public float SailHeight;
	public float SailMoveSpeed = 0.1f;
	public bool shooting = false;
	public bool HandHeight;

	// Use this for initialization
	
	// Update is called once per frame
	void Update ()
	{
		// checks for the player firing
		if (OVRInput.Get (OVRInput.Button.SecondaryHandTrigger)) 
		{
			shooting = true;
		} 
		else 
		{
			shooting = false;
		}

		// increase and decrease speed based on the sails height
		if (GameObject.Find ("OVRRightHand").transform.localPosition.y > 0 && GrabbingSailRight && !shooting && transform.position.y <-0.078) 
		{
			SailHeight = SailHeight + 1;
			transform.Translate (Vector3.up * SailMoveSpeed * Time.deltaTime);
		}
		if (GameObject.Find ("OVRRightHand").transform.localPosition.y < 0 && GrabbingSailRight && !shooting && transform.position.y > -0.094) 
		{
			SailHeight = SailHeight - 1;
			transform.Translate (Vector3.down * SailMoveSpeed * Time.deltaTime);
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == ("PlayerHand"))
		{
			// checks if the player is grabbing the sails
			if (OVRInput.Get (OVRInput.Button.SecondaryIndexTrigger) || (OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger)))
			{
				GrabbingSailLeft = true;
			}
			else
			{
				GrabbingSailLeft = false;	
			}	
		}
	}
}
