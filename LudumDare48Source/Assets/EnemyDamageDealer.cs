using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : DamageDealer
{
        private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            if(IsSpike(collision))
                return;
            
            PlayerLifeManager player = collision.gameObject.GetComponent<PlayerLifeManager>();
            player.TakeDamage(damage);
            Vector3 bumpDirection = (player.transform.position - transform.position).normalized;
            player.GetComponent<Movement>().Bump(bumpDirection);
        }
    }
}
