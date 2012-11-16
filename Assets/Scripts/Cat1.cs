using UnityEngine;
using System.Collections;

public class Cat1 : MonoBehaviour {

	void OnClick()
	{
		audio.PlayOneShot(audio.clip);
		Invoke("NextLevel", 4.8f);
	}
	
	void NextLevel()
	{
		Application.LoadLevel("Scene6");
	}
}
