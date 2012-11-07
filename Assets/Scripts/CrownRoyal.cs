using UnityEngine;
using System.Collections;

public class CrownRoyal : MonoBehaviour {
	Inventory inventory;
	bool has_played;
	
	void Start()
	{
		has_played = false;
		inventory = FindObjectOfType(typeof(Inventory)) as Inventory;
	}

	void OnClick()
	{
		if (!has_played)
		{
			MovieControl ctl = FindObjectOfType(typeof(MovieControl)) as MovieControl;
			ctl.PlayMovie(1);
		
			inventory.has_crown_royal = true;
			has_played = true;
		}
	}
}
