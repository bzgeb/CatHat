using UnityEngine;
using System.Collections;

public class BigSocks : MonoBehaviour {

	Inventory inventory;
	void Start()
	{
		inventory = FindObjectOfType(typeof(Inventory)) as Inventory;
	}
	
	void OnClick()
	{
		if (inventory.has_gun)
		{
			Application.LoadLevel("Scene7");
		}
	}
}
