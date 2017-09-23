using UnityEngine;
using System;
using System.Collections;

public class AttributeSetter : MonoBehaviour 
{
	public void SetData(String name, String value = "")
	{
		foreach(Transform child in transform)
		{
			GameObject item = child.gameObject;
			if(item.tag == "Attribute")
			{
				item.GetComponent<GUIText>().text = name;
			}
			else if(item.tag == "Amount")
			{
				item.GetComponent<GUIText>().text = value;
			}
		}
	}
}