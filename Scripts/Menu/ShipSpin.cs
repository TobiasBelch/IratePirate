using UnityEngine;
using System.Collections;

public class ShipSpin : MonoBehaviour {

	public float Rotate = 50f;
	// spins the players ship around ,use for example
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Used to rotate the ship around a point.
		transform.Rotate (Vector3.up* Rotate * Time.deltaTime);
	}
}
