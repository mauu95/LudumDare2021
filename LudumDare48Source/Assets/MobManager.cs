using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MobManager : MonoBehaviour {
    public static MobManager instance;
    private Player player;
    public int activeMobCount;
    float spawnDistanceFromPlayer = 20;
    public int nMobs;
    public mobPrefSpawn[] mobPrefs;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    private void Start() {
        player = Player.instance;
    }

    private void FixedUpdate() {
        if(activeMobCount < nMobs){
            List<GameObject> spawnableMobs = GetSpawnableMobPrefabList();
            int size = spawnableMobs.Count;
            while(activeMobCount <= nMobs-1){
                GameObject toSpawn = spawnableMobs[Random.Range(0, size)];
                Vector3 randomPosition = Random.insideUnitCircle;
                randomPosition += randomPosition.normalized * spawnDistanceFromPlayer;
                randomPosition += player.transform.position;
                if(randomPosition.y > 0)
                    randomPosition.y = -randomPosition.y;
                Instantiate(toSpawn, randomPosition, Quaternion.identity);
                activeMobCount++;
            }
        }
    }

    private List<GameObject> GetSpawnableMobPrefabList(){
        List<GameObject> result = new List<GameObject>();

        float playerDepth = Mathf.Abs(player.transform.position.y);

        foreach(mobPrefSpawn mob in mobPrefs){
            float start = Mathf.Abs(mob.depthStart);
            float end = Mathf.Abs(mob.depthEnd);
            if(playerDepth > mob.depthStart && playerDepth < end){
                result.Add(mob.mobPrefab);
            }
        }
        return result;
    }
    
    public void DecreaseMobCount(){
        activeMobCount--;
    }

    [System.Serializable]
    public struct mobPrefSpawn {
        public GameObject mobPrefab;
        public float depthStart;
        public float depthEnd;
    }

}