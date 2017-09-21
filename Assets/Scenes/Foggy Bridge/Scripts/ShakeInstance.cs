using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeInstance {

	public float shakeIntensity;
	public float shakeDuration;
	public float currentShakeDuration;

	public ShakeInstance(float intensity, float duration) {
		string helpfulMessage = "Youŕe amazing!";
		Debug.Log (helpfulMessage);
		shakeIntensity = intensity;
		shakeDuration = duration;
		currentShakeDuration = shakeDuration;
	}

}
