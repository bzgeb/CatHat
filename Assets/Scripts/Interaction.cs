using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {
	public Texture2D idle_texture;
	public Texture2D hover_texture;
	Ray ray;
	RaycastHit hit;
	private bool hover;
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (collider.Raycast(ray, out hit, 100))
		{
			renderer.sharedMaterial.mainTexture = hover_texture;
			hover = true;
		}
		else if(hover)
		{
			renderer.sharedMaterial.mainTexture = idle_texture;
			hover = false;
		}
		
		
		if (hover && Input.GetMouseButtonDown(0))
		{
			SendMessage("OnClick");
		}
	}
}
