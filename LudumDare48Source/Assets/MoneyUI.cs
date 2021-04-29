using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    Shop shop;
    public Healthbar bar;

    private void Start() {
        shop = Shop.instance;
        shop.onMoneyChangedCallback += UpdateUI;
    }

    public void UpdateUI(){
        bar.SetHealth(shop.GetMoneyPercentage());
    }
}
