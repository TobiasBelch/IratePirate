using UnityEngine;
using System.Collections;

public class CannonHarpoon : MonoBehaviour 
{
	public float range = 100f;
	public Camera LookCam;
	public Transform Gun;
	public GameObject Cannonball;
	
	// Testing with raycasting
	// Update is called once per frame
	void Update () 
	{
		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
			{
			Shooting();
			}
		}
		void Shooting ()
		{
		RaycastHit hit;
		Physics.Raycast(LookCam.transform.position , LookCam.transform.forward ,out hit , range);
		Instantiate (Cannonball, Gun.position , Gun.rotation);
	}
}
