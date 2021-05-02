using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int moneyDrop;
    public int health;
    public GameObject deadFishPrefab;
    public float maxDistanceFromPlayer = 35;
    private Player player;

    private void Start() {
        player = Player.instance;
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
        else 
            AudioManager.instance.Play("Hit");
    }

    public void Die()
    {
        Instantiate(deadFishPrefab, transform.position, transform.rotation, transform.parent);
        Shop.instance.addMoney(moneyDrop); 
        Despawn();
    }

    public void Despawn(){
        MobManager.instance.DecreaseMobCount();
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        if((transform.position - player.transform.position).magnitude > maxDistanceFromPlayer){
            Despawn();
        }

    }
}
