using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public MovieTexture[] movies;
    public int index;
    public Texture2D UITexture;
    private Camera game_camera;
    
	void Start()
	{
		game_camera = Camera.main;
	}
    
	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, game_camera.pixelWidth, game_camera.pixelHeight), UITexture);
	}
}
