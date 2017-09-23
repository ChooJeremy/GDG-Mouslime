using UnityEngine;
using System.Collections;

public class LargeToSmall : MonoBehaviour 
{
	public float timeTaken = 0.5f;
	public float delayDisplay;
	private Vector3 originalSize;
	private bool finished;

	// Use this for initialization
	void Start() 
	{
		originalSize = gameObject.transform.localScale;
		Vector3 newSize = originalSize * 10;
		//Don't modify z
		newSize.z = originalSize.z;
		finished = false;
		gameObject.transform.localScale = newSize;
		if(delayDisplay > 0)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(delayDisplay > 0)
		{
			delayDisplay -= Time.deltaTime;
			if(delayDisplay <= 0)
			{
				delayDisplay = 0;
				gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}
		}
		else
		{
			if(!finished)
			{
				float amountToDecrease = ((Time.deltaTime * 1/timeTaken) * 200);
				gameObject.transform.localScale -= new Vector3(amountToDecrease, amountToDecrease, 0);

				if(gameObject.transform.localScale.x <= originalSize.x || gameObject.transform.localScale.y <= originalSize.y)
				{
					gameObject.transform.localScale = originalSize;
					finished = true;
				}
			}
		}
	}
}
