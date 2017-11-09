using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttribute : UnitAttributes {

	public float damageMultiplier = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void ApplyAttack(float damageDealt, Vector2 pointOfHit, Color damageColor, params Buff[] attackBuffs) {
		TakeDamage(damageDealt * damageMultiplier, pointOfHit, damageColor, false);

        if (attackBuffs != null) {
            for (int i = 0; i < attackBuffs.Length; i++) {
                ApplyBuff(attackBuffs[i]);
            }
        }
    }

}
