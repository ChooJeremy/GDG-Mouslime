using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOrbBehavior : MonoBehaviour {

	public float RotateSpeed;
 
	public GameObject player;
	public float timeToReturn; 
	public Vector2 offset;
	public float radius;

	private float _angle = 0;
	private float timePassed;
 
	void Start()
	{
		timePassed = 0;
	}
 
	void Update()
	{
		timePassed += Time.deltaTime;

		_angle += RotateSpeed * Time.deltaTime;
 
		var rotateOffset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius * ((timeToReturn - timePassed)/timeToReturn);
		transform.position = (Vector2)player.transform.position + rotateOffset + offset;

		if(timePassed >= timeToReturn) {
			player.GetComponent<CharacterMovement>().upgradeSkill();
			Destroy(gameObject);
		}
	}
}
