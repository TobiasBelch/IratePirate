using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		// Used on the manager parent; preventing the mangers attached to it from being destroyed
		// when a new scene is loaded. Allows the pariables in those scripts to carry over between
		// scenes.
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
