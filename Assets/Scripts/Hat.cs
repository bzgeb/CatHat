using UnityEngine;
using System.Collections;

public class Hat : MonoBehaviour {
	public void OnClick()
	{
		print("Click");
		iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(-2, -2, 0), "time", 2f));
		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 2f));
	}
}
