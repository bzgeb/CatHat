using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Level))]
public class MovieControl : MonoBehaviour {

	public Level level;
	private MovieTexture movie;
	private bool was_playing;
	private Interaction[] interactables;
	
	// Use this for initialization
	void Start () 
	{
		if (level == null)
		{
			level = GetComponent<Level>();
		}
		
		movie = level.movies[0];
		renderer.material.mainTexture = movie;
		level.index = 0;
		
		movie.Play();
		audio.clip = movie.audioClip;
		audio.Play();
		was_playing = true;
		
		MeshFilter mesh_filter = GetComponent<MeshFilter>();
		
		Mesh mesh = new Mesh();
		mesh_filter.mesh = mesh;
		mesh.vertices = new Vector3[]{new Vector3(-8, 4.5f, 0), new Vector3(-8, -4.5f, 0), new Vector3(8, 4.5f, 0), new Vector3(8, -4.5f, 0)};
		mesh.uv = new Vector2[] {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1)};
		mesh.triangles = new int[6] {0, 1, 2, 2, 1, 3};
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (was_playing && !movie.isPlaying)
		{
			level.OnVideoEnd();
			was_playing = false;
		}
	}
	
	public void PlayMovie(int index)
	{
		movie = level.movies[index];
		renderer.material.mainTexture = movie;
		movie.Play();
		audio.clip = movie.audioClip;
		audio.Play();
		
		interactables = FindObjectsOfType(typeof(Interaction)) as Interaction[];
		foreach(Interaction i in interactables)
		{
			i.gameObject.active = false;
		}
		InvokeRepeating("is_done", 1, 0.1f);
	}
	
	void is_done()
	{
		if (!movie.isPlaying)
		{
			movie = level.movies[0];
			audio.clip = movie.audioClip;
			renderer.material.mainTexture = movie;
			CancelInvoke("is_done");
			
			foreach(Interaction i in interactables)
			{
				i.gameObject.active = true;
			}
		}
	}
}
