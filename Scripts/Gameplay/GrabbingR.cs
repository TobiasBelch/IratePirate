using UnityEngine;
using System.Collections;

public class GrabbingR : MonoBehaviour 
{
	public OVRInput.Controller Controller;
	public GameObject Ship;
	public float grabRadius;
	public LayerMask grabmask;

	public GameObject HeldItem;
	public bool grabbing = false;

	// if player is trying to grab ,grabs the object and moves it to your hands location
	void GrabObject()
	{
		grabbing = true;

		RaycastHit[] hits;
		hits = Physics.SphereCastAll (transform.position, grabRadius, transform.forward, 0f, grabmask);

		if (hits.Length > 0) 
		{
			int closeHit = 0;
			for (int i = 0; 1< hits.Length; i++)
			{
				if (hits [i].distance > hits [closeHit].distance)closeHit = i;
			}

			HeldItem = hits [closeHit].transform.gameObject;
			HeldItem.GetComponent<Rigidbody> ().isKinematic = true;
			HeldItem.transform.position = transform.position;
			HeldItem.transform.parent = transform;
		}
	}

	// drops the object
	void DropObject()
	{
		grabbing = false;
		HeldItem.transform.parent = Ship.transform;
		HeldItem.GetComponent<Rigidbody> ().isKinematic = false;

		HeldItem.GetComponent<Rigidbody> ().velocity = OVRInput.GetLocalControllerVelocity(Controller)*6;

		HeldItem = null;
	}
		
	// Checks for player grabbing or dropping the object based on if Hand trigger being pressed
	void Update () 
	{
		if (OVRInput.Get (OVRInput.Button.SecondaryHandTrigger)) GrabObject();
		if (!OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)) DropObject();
	}
}