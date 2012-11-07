using UnityEngine;
using System.Collections;

public class MemoryWindow : MonoBehaviour {

	private bool has_played;
	private Texture2D old_mood;
	public Texture2D silk_mood;
	private Inventory inventory;
	
	void Start()
	{
		has_played = false;
		inventory = FindObjectOfType(typeof(Inventory)) as Inventory;
	}
	
	void OnClick()
	{
		if (!has_played)
		{
			inventory.mood_tex = silk_mood;
			MovieControl ctl = FindObjectOfType(typeof(MovieControl)) as MovieControl;
			ctl.PlayMovie(1);
			has_played = true;
		}
	}
}
