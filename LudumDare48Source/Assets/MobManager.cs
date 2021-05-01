using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour {
    public static MobManager instance;
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    public GameObject nonAggressiveFish;

    


}
