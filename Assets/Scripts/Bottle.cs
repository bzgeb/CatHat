using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {

	void OnClick()
	{
		audio.PlayOneShot(audio.clip);
	}
}
