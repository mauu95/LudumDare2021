using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DumbFishMovement : EnemyMovement
{
    protected override void OnCollisionEnter2D(Collision2D other) {
        base.OnCollisionEnter2D(other);
        if(other.gameObject.CompareTag("Player")){
            SetState(EnemyState.SCARED, 5f);
        }
    }
}
