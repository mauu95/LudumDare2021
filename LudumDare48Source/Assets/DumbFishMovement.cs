using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DumbFishMovement : EnemyMovement
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            SetState(EnemyState.SCARED, 5f);
        }
    }
}
