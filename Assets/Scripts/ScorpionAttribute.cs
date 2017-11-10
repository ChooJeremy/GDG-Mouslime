using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttribute : UnitAttributes {

	public float damageMultiplier = 1;
	public float upgradeHealthBuffer;
	public float timeBetweenBufferRefresh;
	protected float currentHealthBuffer;
	protected float currentBufferTimer;
	protected bool isUpgraded;

	// Use this for initialization
	void Start () {
		currentBufferTimer = 0;
		currentHealthBuffer = 0;
		isUpgraded = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isUpgraded) {
			currentBufferTimer += Time.deltaTime;
			if(currentBufferTimer >= timeBetweenBufferRefresh) {
				currentBufferTimer -= timeBetweenBufferRefresh;
				currentHealthBuffer = upgradeHealthBuffer;
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
    }
}