using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLight : Card
{
    private void Update() {
        if(Player.instance.IsMaxLevel())
            button.gameObject.SetActive(false);
    }
}
