using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerLifeManager : MonoBehaviour {
    public int maxHealth = 100;
    public int health;

    public delegate void OnHealthChanged();
    public OnHealthChanged onHealthChangedCallback;

    void Start() {
        SetMaxHealth();
    }

    private void SetHealth(int amount){
        health = amount;
        if (health >= maxHealth)
            health = maxHealth;
        if(onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    public void SetMaxHealth() {
        SetHealth(maxHealth);
    }

    public void Heal(int amount) {
        int newHealth = health + amount;
        SetHealth(newHealth);
    }


    public void TakeDamage(int amount) {
        int newHealth = health - amount;
        SetHealth(newHealth);
    }
}
