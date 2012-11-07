using UnityEngine;
using System.Collections;

public class Doorframe : MonoBehaviour {

	Inventory inventory;
	void Start()
	{
		inventory = FindObjectOfType(typeof(Inventory)) as Inventory;
	}
	
	void OnClick()
	{
		if (inventory.wearing == Inventory.Hats.detective_hat)
		{
			Application.LoadLevel("Scene3");
		}
		else
		{
			audio.PlayOneShot(audio.clip);
		}
	}
}
