using UnityEngine;
using System.Collections;

public class RobotMoving : MonoBehaviour 
{
	public float MoveSpeed = 0.8f;
	public float RotateSpeed = 60f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.forward * Time.deltaTime * MoveSpeed;
		transform.Rotate (Vector3.up * RotateSpeed * Time.deltaTime);
	}
}
