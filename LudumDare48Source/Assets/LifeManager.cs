using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {
    public float maxLife = 100;
    private float currentLife;

    // Start is called before the first frame update
    void Start() {
        FillLife();
    }

    public void FillLife() {
        currentLife = maxLife;
    }

    public void DealDamage(float damage) {
        currentLife -= damage;
        if (currentLife <= 0) {
            this.gameObject.GetComponent<EnemyMovement>().Die();
            FillLife();
        }
    }

}
