using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour {
    public int enemiesCount = 10;
    public float maxDistance = 100;
    public GameObject enemyContainer;
    public GameObject enemyPrefab;
    public GameObject player;


    private List<GameObject> enemies;

    public static MobManager instance;

    // Start is called before the first frame update
    void Start() {
        if (instance) Destroy(this.gameObject);
        instance = this;

        enemies = new List<GameObject>();
        for (int i = 0; i < enemiesCount; i++) {
            SpawnNewEnemy();
        }
    }

    void SpawnNewEnemy() {
        var randomPosition = Random.insideUnitCircle * 50;
        var playerPos = player.transform.position;
        var position = new Vector3(playerPos.x + randomPosition.x, playerPos.y + randomPosition.y);
        enemies.Add(Instantiate(enemyPrefab, position, Quaternion.identity, enemyContainer.transform));
    }

    public void DestroyEnemy(GameObject enemy) {
        enemies.Remove(enemy);
        Destroy(enemy);
        SpawnNewEnemy();
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < enemies.Count; i++) {
            if ((enemies[i].transform.position - player.transform.position).magnitude >= maxDistance) {
                Destroy(enemies[i]);
            }
        }
    }
}
