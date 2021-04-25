using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLight : Card
{
    private void Update() {
        PlayerStats player = PlayerMovement.instance.GetComponent<PlayerStats>();
        if(player.IsRadiusMaxxedOut())
            button.gameObject.SetActive(false);
    }
}
