using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveEnemyMovement : EnemyMovement {
    public float triggeredTime = 3f;
    protected override void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            SetState(EnemyState.TRIGGERED, triggeredTime);
        }
    }
}
