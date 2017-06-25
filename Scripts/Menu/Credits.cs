using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public float timer = 1;
	public TextMesh text ;
	public int LettersShown = 0;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer= timer + 1;
		if (timer > 100)
		{
			LettersShown = LettersShown + 1;
			timer = 0;
		}


		if (LettersShown == 0)
		{
			text.text= "Gebba Games";
		}

		if (LettersShown == 1)
		{
			text.text=  "Owen Bass";
		}
		if (LettersShown == 2)
		{
			text.text= "Hamzah Ali";
		}
		if (LettersShown == 3)
		{
			text.text= "Myke Edwards";
		}
		if (LettersShown == 4)
		{
			text.text= "Joshua Gomersall";
		}
		if (LettersShown == 5)
		{
			text.text= "Jason Brickley";
		}
		if (LettersShown == 6)
		{
			Destroy (gameObject);
		}	
	}
}
