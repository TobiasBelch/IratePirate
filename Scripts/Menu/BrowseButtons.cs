using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BrowseButtons : MonoBehaviour
{
	public Slider LevelScroller;
	// old style of menu ,No longer used
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.localPosition = new Vector3 (LevelScroller.value, 50, 0);
	}
}
