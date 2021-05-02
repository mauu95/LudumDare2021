using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageDealer : MonoBehaviour {
    public int damage = 5;

    protected bool IsSpike(Collision2D collision){
        DamageDealer otherDamageDealer = null;
        foreach (var c in collision.contacts) {
            otherDamageDealer = c.collider.gameObject.GetComponent<DamageDealer>();
            if (otherDamageDealer)
                break;
        }
        return otherDamageDealer != null;
    }

}
