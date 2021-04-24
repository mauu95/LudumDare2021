using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    public bool isPlayer = false;
    public float damage = 50;

    private void OnCollisionEnter2D(Collision2D collision) {
        // look for spikes
        DamageDealer otherDamageDealer = null;
        foreach (var c in collision.contacts) {
            otherDamageDealer = c.collider.gameObject.GetComponent<DamageDealer>();
            // found a spike!
            if (otherDamageDealer) {
                break;
            }
        }

        // collision with other spike
        if (otherDamageDealer) {
            // TODO: should disable damage for some time on both spikes...
            Debug.Log("collided with another spike!");
            return;
        }
        bool otherIsPlayer = collision.gameObject.tag == "Player";
        if (!isPlayer && otherIsPlayer || isPlayer) {
            var lifeManager = collision.gameObject.GetComponent<LifeManager>();
            if (lifeManager) lifeManager.DealDamage(damage);
        }
    }
}
