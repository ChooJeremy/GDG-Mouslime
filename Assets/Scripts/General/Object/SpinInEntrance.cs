using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SpinInEntrance : MonoBehaviour 
{
	public float angleRatio;
	public float largestSize;

	private Vector3 previousTransform;
	private Vector3 originalTransform;

	// Use this for initialization
	void Start () 
	{
		//Calculate starting angle
		float sizeChange = largestSize - 1f;
		float angleChange = sizeChange * 10 * angleRatio;
		transform.Rotate(new Vector3(0, 0, 1), angleChange % 360);
		previousTransform = transform.localScale;

		originalTransform = previousTransform;
		originalTransform = originalTransform * 0.1f;

		previousTransform *= largestSize;
		transform.localScale = previousTransform;
		StartCoroutine (ReduceScaling());
	}

	IEnumerator ReduceScaling()
	{
		while(Mathf.Round(largestSize * 100f)/100f != 1)
		{
			if(largestSize > 1)
			{
				previousTransform = previousTransform - originalTransform;
				largestSize -= 0.1f;
			}
			else
			{
				previousTransform = previousTransform + originalTransform;
				largestSize += 0.1f;
			}
			transform.Rotate(new Vector3(0, 0, 1), angleRatio * -1f);
			transform.localScale = previousTransform;
			yield return new WaitForSeconds(0.0001f);
		}
		yield break;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}