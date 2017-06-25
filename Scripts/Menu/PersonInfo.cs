using UnityEngine;
using System.Collections;

public class PersonInfo : MonoBehaviour 
{
	public double timer = 1;
	public TextMesh text;
	public int LettersShown = 0;
	
	// Used to change the next in the crdit scene.
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
			text.text= "";
		}

		if (LettersShown == 1)
		{
			text.text=  "Critical Thinker";
		}
		if (LettersShown == 2)
		{
			text.text= "That Art Guy";
		}
		if (LettersShown == 3)
		{
			text.text= "Movement Craftsman";
		}
		if (LettersShown == 4)
		{
			text.text= "Level Inventor";
		}
		if (LettersShown == 5)
		{
			text.text= "Computer Specialist";
		}
		if (LettersShown == 6)
		{
			Destroy (gameObject);
		}	
	}
}
