using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    public int cardType;

    private Shop shop;

    private void Start() {
        shop = FindObjectOfType<Shop>();
    }

    public void onPress() {
        if (!shop) return;

        if (cardType == 0)
            shop.HealPlayer();
        else if(cardType == 1)
            shop.IncreaseLightRadius();
        else
            Debug.LogError("No such card ID");
    }
}
