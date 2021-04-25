using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerLifeManager : MonoBehaviour {
    public TextMeshProUGUI healthText;
    public int maxHealth = 100;
    public int health;

    void Start() {
        FillLife();
    }

    public void FillLife() {
        health = maxHealth;
        UpdateVisual();
    }

    public void Heal(int amount) {
        health += amount;
        if (health >= maxHealth)
            health = maxHealth;
        UpdateVisual();
    }


    public void DealDamage(int damage) {
        health -= damage;
        UpdateVisual();
    }

    private void UpdateVisual() {
        if(healthText)
            healthText.text = "Health: " + health;
    }
}
