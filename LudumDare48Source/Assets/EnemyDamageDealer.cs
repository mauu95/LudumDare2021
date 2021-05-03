using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : DamageDealer
{
    protected override void OnCollisionEnter2D(Collision2D collision) {
        if(IsSpike(collision)){
            Vector3 bumpDirection = (collision.transform.position - transform.position).normalized;
            move.Bump(-bumpDirection);
        }
        else if(collision.gameObject.CompareTag("Player")){
            PlayerLifeManager player = collision.gameObject.GetComponent<PlayerLifeManager>();
            Vector3 bumpDirection = (player.transform.position - transform.position).normalized;
            player.TakeDamage(damage);
            player.GetComponent<Movement>().Bump(bumpDirection);
        }
    }
}
