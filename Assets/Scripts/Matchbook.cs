using UnityEngine;
using System.Collections;

public class Matchbook : MonoBehaviour {
	Inventory inventory;
	
	void Start()
	{
		inventory = FindObjectOfType(typeof(Inventory)) as Inventory;
	}
	
	void OnClick()
	{
		if (inventory.has_crown_royal)
		{
			Application.LoadLevel("Scene5");
		}
	}
}
