using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLight : Card
{
    private void Update() {
        PlayerLightManager player = Player.instance.GetComponent<PlayerLightManager>();
        if(player.IsRadiusMaxxedOut())
            button.gameObject.SetActive(false);
    }
}
