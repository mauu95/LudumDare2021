using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySharkMovement : AggressiveEnemyMovement
{
    [Range(0,1)]
    public float probOfSpawnTriggered = 0.7f;
    private new void Start() {
        base.Start();
        float rand = Random.Range(0f, 1f);
        if(rand < probOfSpawnTriggered)
            SetState(EnemyState.TRIGGERED);
    }
}
