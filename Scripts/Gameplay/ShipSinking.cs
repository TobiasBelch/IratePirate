using UnityEngine;
using System.Collections;

public class ShipSinking : MonoBehaviour 
{
	public float SinkingAmount = -5;
	public float dropamount = 0.1f;
	public float timer;
	
	// makes the ship sink on a timer
	void Update () 
	{
		gameObject.transform.position = new Vector3 (transform.position.x, SinkingAmount, transform.position.z);

		timer = timer + 1; 
		if (timer > 10)
		{
			timer = 0;
			SinkingAmount = SinkingAmount - dropamount;
			if (SinkingAmount == -10)
			{	
				Application.LoadLevel ("Level 1 Complete");
			}
		}
	}
}
