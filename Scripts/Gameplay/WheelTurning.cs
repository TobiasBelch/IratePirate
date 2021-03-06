using UnityEngine;
using System.Collections;

public class WheelTurning : MonoBehaviour 
{
	public float WheelRotate = 200f;
	public bool grabbingWheelLeft;
	public bool grabbingWheelRight;
	public GameObject Wheel;
	public double wheelturn;

	public Transform LeftHand;
	public Transform RightHand;
	public GameObject Ship;
	public float WheelAngle;
	public float WheelAngle2;

	// Spins the wheel based on the hands location around the wheel
	void Update () 
	{
		wheelturn = Wheel.transform.localRotation.z;

		{
		// 90 Degress = 0.7
		// 0 Degress = -0.01
		// -90 degress = -0.7
		// 45 dgress = 0.40
		// -45 dregess = 0.40
		// 22.5 = 0.2
		// -22.5 = -0.2


			if (!grabbingWheelLeft && !grabbingWheelRight) 
			{
				transform.Rotate (0, 0, 0);
			}

		if (grabbingWheelRight && RightHand.localPosition.y < -0.01 && wheelturn >-0.7)
		{	
			transform.Rotate (Vector3.forward * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelRight && RightHand.localPosition.y < -0.2 && wheelturn >-0.4)
		{	
			transform.Rotate (Vector3.forward * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelRight && RightHand.localPosition.y < -0.3 && wheelturn >-0.05)
		{	
			transform.Rotate (Vector3.forward * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelRight && RightHand.localPosition.y > -0.5 && wheelturn <0.05)
		{	
			transform.Rotate (Vector3.back * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelRight && RightHand.localPosition.y > -0.6 && wheelturn <0.40)
		{	
			transform.Rotate (Vector3.back * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelRight && RightHand.localPosition.y > -0.8  && wheelturn <0.70)
		{	
			transform.Rotate (Vector3.back * WheelRotate * Time.deltaTime);
		}
				


		if (grabbingWheelLeft && LeftHand.localPosition.y <-0.01 && wheelturn <0.7) 
		{	
			transform.Rotate (Vector3.back * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelLeft && LeftHand.localPosition.y <-0.2 && wheelturn <0.4)
		{
			transform.Rotate (Vector3.back * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelLeft && LeftHand.localPosition.y <-0.3 && wheelturn <0.05)
		{	
			transform.Rotate (Vector3.back * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelLeft && LeftHand.localPosition.y > -0.5 && wheelturn >-0.05)
		{	
			transform.Rotate (Vector3.forward * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelLeft && LeftHand.localPosition.y > -0.6 && wheelturn >-0.4)
		{	
			transform.Rotate (Vector3.forward * WheelRotate * Time.deltaTime);
		}
		if (grabbingWheelLeft && LeftHand.localPosition.y > -0.8 && wheelturn >-0.7)
		{	
			transform.Rotate (Vector3.forward * WheelRotate * Time.deltaTime);
		}
	}
}
	// only spin the wheel if hands are withing the area of the wheel
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == ("PlayerHand"))
		{
			if (OVRInput.Get (OVRInput.Button.SecondaryIndexTrigger))
			{
				grabbingWheelRight = true;
				grabbingWheelLeft = false;
			}
			else
			{
				grabbingWheelRight = false;	
			}
	
			if (OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger))
			{
				grabbingWheelLeft = true;
				grabbingWheelRight = false;
			}
			else
			{
				grabbingWheelLeft = false;
			}
		}
	}


			//Vector3 direction = new Vector3(RightHand.position.x, RightHand.position.y, 0) - new Vector3(transform.position.x, transform.position.y, 0);
			//if(direction.magnitude > 0.1f )
			//{
			//	if( Vector3.Dot( Vector3.right, direction ) > 0 )
			//	{
			//		transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, 90);
			//	}
			//	else
			//	{
			//		transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 270, 270);
			//	}
	//		}
//		}

		//Vector3 direction = new Vector3(LeftHand.position.x, LeftHand.position.y, 0) - new Vector3(transform.position.x, transform.position.y, 0);

		//if(direction.magnitude > 0.1f )
		//{
		//	if( Vector3.Dot( Vector3.right, direction ) > 0 )
		//	{
		//		transform.rotation = Quaternion.LookRotation( direction ) * Quaternion.Euler( 0, 90, 90 );
		//	}
		//	else
		//	{
		//		transform.rotation = Quaternion.LookRotation( direction ) * Quaternion.Euler( 0, 270, 270);
		//	}
	//	}
//	}
}
