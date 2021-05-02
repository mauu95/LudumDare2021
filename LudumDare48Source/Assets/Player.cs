using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    private PlayerLightManager lightManager;
    private PlayerEnergyManager energyManager;
    private Shop shop;
    private PlayerDamageDealer spike;
    private PlayerMovement movementManager;
    private float initialPlayerSpeed;
    public int level;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start() {
        lightManager = GetComponent<PlayerLightManager>();
        energyManager = GetComponent<PlayerEnergyManager>();
        shop = Shop.instance;
        spike = GetComponentInChildren<PlayerDamageDealer>();
        movementManager = GetComponent<PlayerMovement>();
        initialPlayerSpeed = movementManager.speed;
    }

    public void LevelUp(){
        level++;
        transform.localScale = Vector3.one * (1+(0.1f)*level);
        movementManager.speed = initialPlayerSpeed + level;
        spike.damage = 5*level;
        lightManager.SetLightRadiusBasedOnLevel(level);
        energyManager.UpdateDecay(level);
        shop.UpdatePrice(level);
    }

    public bool IsMaxLevel(){
        return level == 10;
    }

    
}
