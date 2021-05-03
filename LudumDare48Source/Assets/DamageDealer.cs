using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageDealer : MonoBehaviour {
    public int damage;
    protected Movement move;

    private void Start() {
        move = GetComponentInParent<Movement>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D other) {

    }

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
