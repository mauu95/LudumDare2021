using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour {
    public static MobManager instance;
    private List<Enemy> activeMobs;
    private Player player;
    public int activeMobCount;
    public int nMobs;
    public mobPrefSpawn[] mobPrefs;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    private void Start() {
        activeMobs = new List<Enemy>();
        player = Player.instance;
    }

    private void FixedUpdate() {
        activeMobCount = activeMobs.Count;
        if(activeMobCount < nMobs){
            List<GameObject> spawnableMobs = GetSpawnableMobPrefabList();
            int size = spawnableMobs.Count;
            while(activeMobCount <= nMobs-1){
                int n = Random.Range(0, size);
                GameObject toSpawn = spawnableMobs[n];
                var randomPosition = Random.insideUnitCircle * 50;
                activeMobs.Add(Instantiate(toSpawn, randomPosition, Quaternion.identity).GetComponent<Enemy>());
            }
        }
    }

    private List<GameObject> GetSpawnableMobPrefabList(){
        List<GameObject> result = new List<GameObject>();

        float playerDepth = Mathf.Abs(player.transform.position.y);

        foreach(mobPrefSpawn mob in mobPrefs){
            float start = Mathf.Abs(mob.depthStart);
            float end = Mathf.Abs(mob.depthStart);
            if(playerDepth > mob.depthStart && playerDepth < end){}
                result.Add(mob.mobPrefab);
        }
        return result;
    }

    [System.Serializable]
    public struct mobPrefSpawn {
        public GameObject mobPrefab;
        public float depthStart;
        public float depthEnd;
    }

}
