using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    public bool isPlayer = false;
    public int damage = 50;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Background"))return;
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
            return;
        }
        bool otherIsPlayer = collision.gameObject.tag == "Player";
        if (isPlayer) {
            var lifeManager = collision.gameObject.GetComponent<EnemyLifeManager>();
            lifeManager.TakeDamage(damage);
            var rb = this.gameObject.GetComponentInParent<Rigidbody2D>();
            var controller = collision.gameObject.GetComponent<EnemyMovement>();
            controller.Bump(rb.velocity);
        }
        if (otherIsPlayer) {
            var lifeManager = collision.gameObject.GetComponent<PlayerLifeManager>();
            lifeManager.TakeDamage(damage);
            var bumpDirection = (collision.gameObject.transform.position - transform.position).normalized;
            var controller = collision.gameObject.GetComponentInParent<PlayerMovement>();
            controller.Bump(bumpDirection * 10);

        }
    }
}
