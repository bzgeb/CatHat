using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	void OnClick()
	{
		iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(-6, 0, 0), "time", 1f));
		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 1f));
		Inventory inventory = FindObjectOfType(typeof(Inventory)) as Inventory;
		inventory.has_gun = true;
	}
}
