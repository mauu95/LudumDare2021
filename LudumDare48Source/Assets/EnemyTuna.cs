using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTuna : Enemy
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            if(Player.instance.level < 1)
                HintUI.instance.SetText("It seems he is too fast");
        }
    }
}
