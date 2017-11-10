using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttribute : UnitAttributes {

	public float damageMultiplier = 1;
	public float upgradeHealthBuffer;
	public float timeBetweenBufferRefresh;
	public GameObject shieldObject;
	public float shieldFlashTime;

	//improvement!
	public GameObject improvementOrb;
	public GameObject mainEnemy;
	protected UnitAttributes enemyAttributes;
	protected float enemyMaxHealth;

	protected MeshRenderer shieldRenderer;
	protected float currentHealthBuffer;
	protected float currentBufferTimer;
	protected bool isUpgraded;
	protected float timeToDisplayShield;

	// Use this for initialization
	void Start () {
		currentBufferTimer = 0;
		currentHealthBuffer = 0;
		timeToDisplayShield = 0;
		isUpgraded = false;
		shieldRenderer = shieldObject.GetComponent<MeshRenderer>();
		shieldRenderer.enabled = false;
		if(mainEnemy == null) {
			//assign one.
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			for(int i = 0; i < enemies.Length; i++) {
				if(enemies[i].GetComponent<UnitAttributes>() != null) {
					mainEnemy = enemies[i];
				}
			}
			if(mainEnemy == null) { //still not found
				//just pick one.
				mainEnemy = enemies[0];
			}
		}
		enemyAttributes = mainEnemy.GetComponent<UnitAttributes>();
		enemyMaxHealth = enemyAttributes.CurrentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyAttributes.CurrentHealth * 2 < enemyMaxHealth) {
			improvementOrb.GetComponent<UpgradeOrbBehavior>().isActive = true;
			enemyMaxHealth = 0;
		}
		if(isUpgraded) {
			currentBufferTimer += Time.deltaTime;
			if(currentBufferTimer >= timeBetweenBufferRefresh) {
				currentBufferTimer -= timeBetweenBufferRefresh;
				currentHealthBuffer = upgradeHealthBuffer;
				timeToDisplayShield = shieldFlashTime;
			}
		}
		if(timeToDisplayShield > 0) {
			timeToDisplayShield -= Time.deltaTime;
			if(timeToDisplayShield > 0) {
				shieldRenderer.enabled = true;
			} else {
				shieldRenderer.enabled = false;
			}
		}
	}

	public override void ApplyAttack(float damageDealt, Vector2 pointOfHit, Color damageColor, params Buff[] attackBuffs) {
		float damageToTake = damageDealt * damageMultiplier;
		if(currentHealthBuffer > 0) {
			if(currentHealthBuffer > damageToTake) {
				damageToTake = 0;
				currentHealthBuffer -= damageToTake;
			} else {
				damageToTake -= currentHealthBuffer;
				currentHealthBuffer = 0;
			}
			timeToDisplayShield = shieldFlashTime;
		}
		TakeDamage(damageToTake, pointOfHit, damageColor, false);

        if (attackBuffs != null) {
            for (int i = 0; i < attackBuffs.Length; i++) {
                ApplyBuff(attackBuffs[i]);
            }
        }
    }

    public void gainDefences() {
    	isUpgraded = true;
    	currentHealthBuffer = upgradeHealthBuffer;
    	timeToDisplayShield = shieldFlashTime;
    }
}