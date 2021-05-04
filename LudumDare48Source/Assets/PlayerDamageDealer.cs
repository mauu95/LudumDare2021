using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDealer : DamageDealer
{
    protected override void OnCollisionEnter2D(Collision2D collision) {
        if(IsSpike(collision)){
            Vector3 bumpDirection = (collision.transform.position - transform.position).normalized;
            move.Bump(-bumpDirection);
            AudioManager.instance.Play("HitMetal");
        }
        else if(collision.gameObject.CompareTag("Enemy")){
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Vector3 bumpDirection = (enemy.transform.position - transform.position).normalized;
            enemy.TakeDamage(damage);
            enemy.GetComponent<Movement>().Bump(bumpDirection);
            AudioManager.instance.Play("Hit");
        }
    }
}

