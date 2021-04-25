using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour {
    public float maxLife = 100;
    public GameObject deadFishPrefab;
    protected float currentLife;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        FillLife();
        audioSource = GetComponent<AudioSource>();
    }

    public void FillLife() {
        currentLife = maxLife;
    }



    public void DealDamage(float damage) {
        currentLife -= damage;
        MobManager.instance.AddAggroTo(gameObject);
        if (currentLife <= 0) {
            Instantiate(deadFishPrefab, transform.position, transform.rotation, transform.parent);
            this.gameObject.GetComponent<EnemyMovement>().Die();
            FillLife();
        } else {
            audioSource.Play();
        }
    }

}
