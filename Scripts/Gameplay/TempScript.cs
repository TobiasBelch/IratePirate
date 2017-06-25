using UnityEngine;
using System.Collections;

public class TempScript : MonoBehaviour {

	public GameObject Camera;
	public GameObject Player;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey("a"))
		{
			Camera.transform.Rotate(0, -1, 0);
		}

		if (Input.GetKey("d"))
		{
			Camera.transform.Rotate(0, 1, 0);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Player.transform.Rotate(0, -1, 0);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			Player.transform.Rotate(0, 1, 0);
		}
	}
}