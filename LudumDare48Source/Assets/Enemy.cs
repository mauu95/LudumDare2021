using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int moneyDrop;

    private EnemyMovement posManager;

    private void Start()
    {
        posManager = GetComponent<EnemyMovement>();
    }

    public void Die()
    {
        posManager.ResetPosition();
        FindObjectOfType<Shop>().addMoney(moneyDrop);
    }
}
