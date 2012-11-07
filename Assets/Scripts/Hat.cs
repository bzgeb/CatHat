using UnityEngine;
using System.Collections;

public class Hat : MonoBehaviour {
	public void OnClick()
	{
		iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(-6, 0, 0), "time", 2f));
		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 2f));
		
		StartCoroutine(GetHat());
	}
	
	IEnumerator GetHat()
	{
		yield return new WaitForSeconds(1);
		
		Inventory inventory = FindObjectOfType(typeof(Inventory)) as Inventory;
		inventory.has_detective_hat = true;
	}
}
