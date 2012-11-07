using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public bool has_detective_hat;
	public Texture2D detective_hat_tex;
	private Rect detective_hat_box;
	public bool has_crown_royal;
	private Rect crown_royal_box;
	public Texture2D crown_royal_tex;
	public Texture2D gun_tex;
	public bool has_gun;
	private Rect gun_box;
	private Rect mood_box;
	public Texture2D mood_tex;
	private float detective_hat_angle;
	private Rect wearing_box;
	private Rect inventory_box;
	public Hats wearing = Hats.no_hat;
	
	private bool in_transition;
	private float transition_time;
	private Rect from_box;
	private Rect to_box;
	
	public enum Hats
	{
		no_hat,
		detective_hat
	}
	
	void Start()
	{
		wearing_box = new Rect(Screen.width * 0.2f, Screen.height * 0.85f, Screen.width * 0.1f, Screen.height * 0.1f);
		
		detective_hat_box = new Rect(Screen.width * 0.03f, Screen.height * 0.07f, Screen.width * 0.08f, Screen.height * 0.08f);
		crown_royal_box = new Rect(Screen.width * 0.36f, Screen.height * 0.85f, Screen.width * 0.1f, Screen.height * 0.12f);
		
		gun_box = new Rect(Screen.width * 0.45f, Screen.height * 0.85f, Screen.width * 0.1f, Screen.height * 0.12f);
		
		mood_box = new Rect(Screen.width * 0.735f, Screen.height * 0.83f, Screen.width * 0.15f, Screen.height * 0.15f);
		
		transition_time = 0;
		in_transition = false;
		
		detective_hat_angle = 350;
	}
	
	void Update()
	{
		if (in_transition)
		{
			switch(wearing)
			{
			case Hats.detective_hat:
				transition(ref detective_hat_box);
				
				if (transition_time > 1)
					end_transition(ref detective_hat_box);
					
				break;
			}

		}
	}
	
	void OnGUI()
	{
		GUI.depth = 1;
		GUI.Box(mood_box, mood_tex, GUIStyle.none);
		
		if (has_detective_hat)
		{
			GUIUtility.RotateAroundPivot(detective_hat_angle, new Vector2(detective_hat_box.x + detective_hat_box.width / 2, detective_hat_box.y + detective_hat_box.height / 2));
			if(GUI.Button(detective_hat_box, detective_hat_tex, GUIStyle.none))
			{
				from_box = detective_hat_box;
				to_box = wearing_box;
				
				wearing = Hats.detective_hat;
				
				in_transition = true;
				transition_time = 0;
			}
		}
		GUI.matrix = Matrix4x4.identity;
		
		if (has_crown_royal)
		{
			GUI.Box(crown_royal_box, crown_royal_tex, GUIStyle.none);
		}
		
		if (has_gun)
		{
			GUI.Box(gun_box, gun_tex, GUIStyle.none);
		}
		
		switch(wearing)
		{
		case Hats.no_hat:
			break;
			
		case Hats.detective_hat:
			GUI.Box(wearing_box, detective_hat_tex, GUIStyle.none);
			break;
		}
	}
	
	void transition(ref Rect box)
	{
		box.x = Mathf.Lerp(from_box.x, to_box.x, transition_time);
		box.y = Mathf.Lerp(from_box.y, to_box.y, transition_time);
		box.width  = Mathf.Lerp(from_box.width, to_box.width, transition_time);
		box.height = Mathf.Lerp(from_box.height, to_box.height, transition_time);
		
		detective_hat_angle = Mathf.Lerp(0, 350, transition_time);
		
		transition_time += Time.deltaTime;
	}
	
	void end_transition(ref Rect box)
	{
		box.x = from_box.x;
		box.y = from_box.y;
		box.width = from_box.width;
		box.height = from_box.height;
		
		in_transition = false;
	}
}
