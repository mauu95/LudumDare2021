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

    private void SetHealth(int amount) {
        health = amount;
        if (health >= maxHealth)
            health = maxHealth;
        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    public void SetMaxHealth() {
        Heal(1000);
    }

    public void Heal(int amount) {
        int newHealth = health + amount;
        SetHealth(newHealth);
    }


    public void TakeDamage(int amount) {
        if (health <= 0) return; // you already died
        int newHealth = health - amount;
        SetHealth(newHealth);
        if (health <= 0) {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame() {
        Time.timeScale = 0.05f;
        yield return new WaitForSecondsRealtime(2);
        //TODO implementa il maxscore
        int maxScore = 0;
        if (ScoreManager.instance)
            ScoreManager.instance.GameEnd(maxScore);
    }


}
