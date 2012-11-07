using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public MovieTexture[] movies;
    public int index;
    public Texture2D UITexture;
    private Camera game_camera;
    public GameObject[] objects;
    
	void Start()
	{
		game_camera = Camera.main;
	}
    
	void OnGUI()
	{
		GUI.depth = 100;
		GUI.Box(new Rect(0, 0, game_camera.pixelWidth, game_camera.pixelHeight), UITexture);
	}
	
	public void OnVideoEnd()
	{
		foreach(GameObject obj in objects)
		{
			obj.SetActiveRecursively(true);
		}
	}
}
