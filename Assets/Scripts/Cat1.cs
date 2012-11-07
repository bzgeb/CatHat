using UnityEngine;
using System.Collections;

public class Cat1 : MonoBehaviour {

	void OnClick()
	{
		audio.PlayOneShot(audio.clip);
	}
}
