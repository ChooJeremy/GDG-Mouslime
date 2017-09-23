using UnityEngine;
using System.Collections;

public class IncreaseBounce : MonoBehaviour 
{
	public float constantIncrase;
	public float timeIncrease;
	public float scaleRate;
	private Vector3 startingScale;
	private float timePassed;

	void Awake()
	{
		startingScale = gameObject.transform.localScale;
		timePassed = 0;
	}

	void FixedUpdate()
	{
		timePassed += timeIncrease;
		startingScale.x += constantIncrase;
		startingScale.y += constantIncrase;
		Vector3 newScale = startingScale;
		newScale.x += Mathf.Sin(timePassed) * scaleRate;
		newScale.y += Mathf.Sin(timePassed) * scaleRate;
		gameObject.transform.localScale = newScale;
	}
}
