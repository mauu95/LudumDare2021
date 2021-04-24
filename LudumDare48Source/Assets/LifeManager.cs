using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {
    public float maxLife = 100;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void DealDamage(float damage) {
        maxLife -= damage;
        if (maxLife <= 0) Destroy(this.gameObject);
    }

}
