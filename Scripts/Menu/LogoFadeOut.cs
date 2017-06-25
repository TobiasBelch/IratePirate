using UnityEngine;
using System.Collections;

public class LogoFadeOut : MonoBehaviour 
{
	public float TextureVis = 0;
	public float timer = 0;
	public float destroyorder = 1;
	
	// Used to destroy the credit objects in a set order
	void Update () 
	{		
		timer = timer + 1;

		if (timer > 100)
		{
			timer = 0;
			TextureVis = TextureVis + 1;
		}

		if (TextureVis == destroyorder)
		{
			Destroy (gameObject);
		}
	}
}
