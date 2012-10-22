using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Level))]
public class MovieControl : MonoBehaviour {

	public Level level;
	
	// Use this for initialization
	void Start () 
	{
		if (level == null)
		{
			level = GetComponent<Level>();
		}
		
		
		renderer.material.mainTexture = level.movies[0];
		level.index = 0;
		
		((MovieTexture)renderer.material.mainTexture).Play();
		
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
		if (Input.GetKeyDown(KeyCode.Space))
		{
			((MovieTexture)renderer.material.mainTexture).Pause();
			
			level.index = (level.index + 1) % level.movies.Length;
			renderer.material.mainTexture = level.movies[level.index];
			
			((MovieTexture)renderer.material.mainTexture).Play();
		}
	}
}
