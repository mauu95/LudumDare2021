using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour {
    public float maxLife = 100;
    public GameObject deadFishPrefab;
    protected float currentLife;

    void Start() {
        FillLife();
    }

    public void FillLife() {
        currentLife = maxLife;
    }

    public void TakeDamage(float damage) {
        currentLife -= damage;
        MobManager.instance.AddAggroTo(gameObject);
        if (currentLife <= 0) {
            GetComponent<Enemy>().Die();
            Instantiate(deadFishPrefab, transform.position, transform.rotation, transform.parent);
            FillLife();
        } else {
            AudioManager.instance.Play("Hit");
        }
    }

}
