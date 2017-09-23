using UnityEngine;
using System.Collections;

public class FadeOverTime : MonoBehaviour 
{
	public float delay;
	private bool fade;

	// Use this for initialization
	void Start() 
	{
		fade = false;
		StartCoroutine (StartFading());
	}

	IEnumerator StartFading()
	{
		if(delay < 0)
		{
			yield break;
		}
		yield return new WaitForSeconds(delay);
		fade = true;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(fade)
		{
			Color temp = gameObject.GetComponent<Renderer>().material.color;
			temp.a -= 0.01f;
			gameObject.GetComponent<Renderer>().material.color = temp;
			if(gameObject.GetComponent<Renderer>().material.color.a <= 0.0f)
			{
				Destroy(gameObject);
			}
		}
	}
}
