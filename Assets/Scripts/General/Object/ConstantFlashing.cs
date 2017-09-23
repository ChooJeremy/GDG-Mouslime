using UnityEngine;
using System.Collections;

public class ConstantFlashing : MonoBehaviour 
{
	private int direction;
	public float minimumAlpha = 0.5f;

	// Use this for initialization
	void Start() 
	{
		if(gameObject.GetComponent<Renderer>().material.color.a >= 1)
		{
			direction = -1;
		}
		else
		{
			direction = 1;
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		Color temp = gameObject.GetComponent<Renderer>().material.color;
		temp.a += 0.01f * direction;
		gameObject.GetComponent<Renderer>().material.color = temp;
		if(gameObject.GetComponent<Renderer>().material.color.a <= minimumAlpha || gameObject.GetComponent<Renderer>().material.color.a >= 1f)
		{
			direction *= -1;
			if(gameObject.GetComponent<Renderer>().material.color.a >= 1f)
			{
				temp.a = 1f;
			}
			else
			{
				temp.a = minimumAlpha;
			}
			gameObject.GetComponent<Renderer>().material.color = temp;
		}
	}
}
