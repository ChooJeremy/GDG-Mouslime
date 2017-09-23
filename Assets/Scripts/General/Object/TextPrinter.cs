using UnityEngine;
using System.Collections;

public class TextPrinter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(GetComponent<GUIText>().text);
		Debug.Log(gameObject.GetComponent<GUIText>().text);
	}
}
