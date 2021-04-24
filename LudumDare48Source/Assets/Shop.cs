using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region Singleton
    public static Shop instance;
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }
    #endregion

    public GameObject shopUI;
    public int money;
    public int price;

    public void OpenShop(){
        shopUI.SetActive(true);
    }

    public void addMoney(int amount){
        money += amount;

        if(money >= price){
            OpenShop();
        }
    }

    public void spendMoney(int amount){
        if(money - amount >= 0)
            money -= amount;
    }
}
