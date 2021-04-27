using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHealth : Card
{
    private void Update() {
        PlayerLifeManager player = Player.instance.GetComponent<PlayerLifeManager>();
        if(player.health == player.maxHealth)
            button.gameObject.SetActive(false);
    }
}
