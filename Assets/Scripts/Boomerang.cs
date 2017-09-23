using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Boomerang : Projectile 
{
	public float degreeRotationPerSecond;
	public float timeBeforeReturn;

	private GameObject thrower;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(new Vector3(0, 0, 1), degreeRotationPerSecond * Time.deltaTime);
		if(timeBeforeReturn > 0) {
			timeBeforeReturn -= Time.deltaTime;
		}
		if(timeBeforeReturn <= 0) {
			Vector3 oldVelocity = projectileRigidbody.velocity;
			unitProjectileDirection = (thrower.transform.position - transform.position).normalized;
			oldVelocity.x += unitProjectileDirection.x * Time.deltaTime * projectileSpeed;
			oldVelocity.y += unitProjectileDirection.y * Time.deltaTime * projectileSpeed;
			projectileRigidbody.velocity = oldVelocity;
			//Debug.Log(oldVelocity);
			//projectileRigidbody.AddForce(unitProjectileDirection * Time.deltaTime * projectileSpeed);
		}
	}

	// Sets up projectile properties
    public void SetupProjectile(float damage, float speed, float lifespan, Vector2 direction, GameObject throwPerson, params Buff[] buffs) {
        projectileDamage = damage;
        projectileSpeed = speed;
        projectileLifespan = lifespan;
        projectileBuffs = buffs;
        unitProjectileDirection = direction.normalized;
        projectileRigidbody.velocity = unitProjectileDirection * projectileSpeed;
        thrower = throwPerson;
    }
		
	protected override void UpdateProjectile() {
		// Sets the projectile velocity to move in assigned direction at assigned speed
        //projectileRigidbody.velocity = unitProjectileDirection * projectileSpeed;
    }

	protected override void OnHitEnemy(GameObject hitObject) {
		// Gets the component (of the target hit) that controls the health,
		UnitAttributes targetAttributes = hitObject.GetComponent<UnitAttributes> ();

		// and deal damage to it
		targetAttributes.ApplyAttack (projectileDamage, projectileBuffs);

		// projectile dies
	}

	protected override void OnHitFriendly(GameObject o) {
		if(timeBeforeReturn <= 0) {
			OnProjectileDeath();
		}
	}

	protected override void OnHitStructure (GameObject hitObject) {
		// If projectile hits a wall, projectile dies
		//OnProjectileDeath ();
	}

	protected override void OnProjectileDeath () {
		// Delete (destroy) the gameobject
		Destroy (this.gameObject);
	}
}