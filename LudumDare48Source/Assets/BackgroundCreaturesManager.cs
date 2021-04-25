using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCreaturesManager : MonoBehaviour {
    public GameObject[] creatures;
    public int creaturesCount = 20;

    private List<GameObject> spawnedCreature = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < creaturesCount; i++) {
            int randPosition = (int)(Random.value * creatures.Length);
            GameObject spawned = Instantiate(creatures[randPosition], transform);
            spawnedCreature.Add(spawned);
        }
    }

}
