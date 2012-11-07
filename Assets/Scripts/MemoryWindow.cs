using UnityEngine;
using System.Collections;

public class MemoryWindow : MonoBehaviour {

	private bool has_played;
	void Start()
	{
		has_played = false;
	}
	
	void OnClick()
	{
		if (!has_played)
		{
			MovieControl ctl = FindObjectOfType(typeof(MovieControl)) as MovieControl;
			ctl.PlayMovie(1);
			has_played = true;
		}
	}
}
