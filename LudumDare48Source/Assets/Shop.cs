using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }
    
    public GameObject shopUI;
    public int money;
    public int price;

    private GameObject player;

    public delegate void OnMoneyChanged();
    public OnMoneyChanged onMoneyChangedCallback;

    private void Start() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    public void OpenShop(){
        shopUI.SetActive(true);
        shopUI.GetComponent<ShopUI>().EnableAllCards();
        GameManager.instance.slowTime(true);
        AudioManager.instance.Play("OpenShop");
    }

    public void CloseShop(){
        shopUI.SetActive(false);
        GameManager.instance.slowTime(false);
    }

    public void purchaseHeal(){
        player.GetComponent<PlayerLifeManager>().SetMaxHealth();
        AudioManager.instance.Play("GainHealth");
        ResetMoney();
    }

    public void purchaseLight(){
        player.GetComponent<Player>().LevelUp();
        AudioManager.instance.Play("GainLight");
        ResetMoney();
    }

    public void purchaseEnergy(){
        player.GetComponent<PlayerEnergyManager>().FillEnergy();
        AudioManager.instance.Play("GainEnergy");
        ResetMoney();
    }

    public void ResetMoney()
    {
        money = 0;
        if(onMoneyChangedCallback != null)
            onMoneyChangedCallback.Invoke();
    }

    public void addMoney(int amount){
        money += amount;

        if(money >= price){
            OpenShop();
        }

        if(onMoneyChangedCallback != null)
            onMoneyChangedCallback.Invoke();
    }

    public void SetPrice(int amount)
    {
        price = amount;
    }

    public void UpdatePrice(int difficulty)
    {
        SetPrice(difficulty * 20);
    }
    
    public float GetMoneyPercentage(){
        return money*1f / price * 100;
    }
}
