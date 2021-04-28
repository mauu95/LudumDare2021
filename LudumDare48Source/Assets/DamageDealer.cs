using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    public int damage = 5;

    private bool IsSpike(Collision2D collision){
        DamageDealer otherDamageDealer = null;
        foreach (var c in collision.contacts) {
            otherDamageDealer = c.collider.gameObject.GetComponent<DamageDealer>();
            if (otherDamageDealer)
                break;
        }
        return otherDamageDealer != null;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Enemy")){
            if(IsSpike(collision))
                return;
            
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            Vector3 bumpDirection = (enemy.transform.position - transform.position).normalized;
            enemy.GetComponent<Movement>().Bump(bumpDirection * 10);
        }

        /*bool otherIsPlayer = collision.gameObject.tag == "Player";
        if (isPlayer) {
            var lifeManager = collision.gameObject.GetComponent<Enemy>();
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

        }*/
    }
}
