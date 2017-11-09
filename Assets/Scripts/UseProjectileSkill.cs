using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseProjectileSkill : MonoBehaviour {

	// Prefabs
	[SerializeField]
	private GameObject projectile;

	// Objects
	[SerializeField]
	private Transform firingPivot;

	// Fields
	[SerializeField]
	private float projectileDamage;
	[SerializeField]
	private float projectileSpeed;
	[SerializeField]
	private float projectileLifeSpan;
	[SerializeField]
	private float projectileCooldown;

	protected SpriteRenderer shooterSprite;
	protected CharacterMovement characterInformation;

	private MovementSpeedBuff projectileBuff;
	public int maximumTotalAllowedOnScreen;

	private void Awake() {

		// Uncomment this (and put projectileBuff as an argument in SetupProjectile()) to apply a slow buff to the example character's projectiles
		//projectileBuff = new MovementSpeedBuff (.75f, "EXAMPLE_SLOW", 3, null, false);
		shooterSprite = gameObject.GetComponent<SpriteRenderer>();
		characterInformation = gameObject.GetComponent<CharacterMovement>();
	}

	// Runtime variables
	private float currentProjectileCooldown = 0;

	// Executes every frame
	private void Update () {

		// Skill is on cooldown?
		if (currentProjectileCooldown > 0) {

			// Decrease cooldown time according to frame time
			currentProjectileCooldown -= Time.deltaTime;
		}

		// Pressed C button and skill is off cooldown?
		if (Input.GetMouseButtonDown(0) && currentProjectileCooldown <= 0) {
			
			FireProjectile();

			// Set cooldown for the skill
			currentProjectileCooldown = projectileCooldown;
		}

		// Pressed C button and skill is off cooldown?
        else if (Input.GetKey(KeyCode.C) && currentProjectileCooldown <= 0) {

			// Fire projectile at target
            FireForward();

			// Set cooldown for the skill
            currentProjectileCooldown = projectileCooldown;
        }

	}

	private bool fireCheck() {
		if(characterInformation.isBlocking) {
			Debug.Log("Blocking, can't fire");
			return false;
		}

		if(maximumTotalAllowedOnScreen > 0) {
			maximumTotalAllowedOnScreen--;
			return true;
		} else {
			return false;
		}
	}

	private void FireProjectile() {

		if(!fireCheck()) {
			return;
		}

		// Create a projectile
		GameObject newProjectile = (GameObject) Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(Vector3.zero));

		// Calculate character's shooting direction
		Vector3 screenMousePos = Input.mousePosition;
		screenMousePos.z = Camera.main.transform.position.z;
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(screenMousePos);
		Vector2 facingVector = (mouseWorldPos - firingPivot.position);

		// Setup projectile attribute (like damage, speed, etc)
		//Debug.Assert(newProjectile.GetComponent<ExampleLinearProjectile>(), "Projectile does not contain the LinearProjectile component. Check if you getting the correct component.");
		newProjectile.GetComponent<Boomerang>().SetupProjectile(projectileDamage, projectileSpeed, projectileLifeSpan, facingVector, gameObject, null);

		// Use this if using projectileBuff
		//newProjectile.GetComponent<ExampleLinearProjectile>().SetupProjectile(projectileDamage, projectileSpeed, projectileLifeSpan, facingVector, projectileBuff);
	}

	private void FireForward() {
		if(!fireCheck()) {
			return;
		}

		// Create a projectile
        GameObject newProjectile = (GameObject) Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(Vector3.zero));

		// Calculate character's shooting direction
		Vector2 facingVector = new Vector2(1, 0);
		if(shooterSprite.flipX) {
			facingVector = new Vector2(-1, 0);
		}

		// Setup projectile attribute (like damage, speed, etc)
        //Debug.Assert(newProjectile.GetComponent<ExampleHomingProjectile>(), "Projectile does not contain the HomingProjectile component. Check if you getting the correct component.");
		newProjectile.GetComponent<Boomerang>().SetupProjectile(projectileDamage, projectileSpeed, projectileLifeSpan, facingVector, gameObject, null);
	}

}
