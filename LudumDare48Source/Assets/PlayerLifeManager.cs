using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerLifeManager : MonoBehaviour {
    public TextMeshProUGUI healthText;
    public float maxLife = 100;
    protected float currentLife;

    // Start is called before the first frame update
    void Start() {
        FillLife();
    }

    public void FillLife() {
        currentLife = maxLife;
    }

    public void Heal(float amount) {
        currentLife += amount;
        if (currentLife >= maxLife)
            currentLife = maxLife;
        UpdateVisual();
    }


    public void DealDamage(float damage) {
        currentLife -= damage;
        UpdateVisual();
    }

    private void UpdateVisual() {
        healthText.text = "Health: " + currentLife;
    }
}
