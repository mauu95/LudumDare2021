using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour {
    public int enemiesCount = 10;
    public int enemiesCountWithAggro = 3;
    public float changeAggroInterval = 10f;
    public GameObject enemyContainer;
    public GameObject enemyPrefab;

    private List<GameObject> enemies;
    private List<GameObject> enemiesWithAggro;
    private float elapsedTime = 0;

    public static MobManager instance;

    // Start is called before the first frame update
    void Start() {
        if (instance) Destroy(this.gameObject);
        instance = this;

        enemies = new List<GameObject>();
        enemiesWithAggro = new List<GameObject>();

        for (int i = 0; i < enemiesCount; i++) {
            enemies.Add(Instantiate(enemyPrefab, transform));
        }
    }

    void RemoveAggroToEveryone() {
        foreach (var enemy in enemiesWithAggro) {
            enemy.GetComponent<EnemyMovement>().RemoveAggro();
        }
        enemiesWithAggro.Clear();
    }


    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= changeAggroInterval) {
            elapsedTime = 0;
            RemoveAggroToEveryone();
            for (int i = 0; i < enemiesCountWithAggro; i++) {
                var randomPosition = (int)Random.value * enemies.Count;
                GameObject enemyWithAggro = enemies[randomPosition];
                enemyWithAggro.GetComponent<EnemyMovement>().AddAggro();
                enemiesWithAggro.Add(enemyWithAggro);
            }
        }
    }
}
