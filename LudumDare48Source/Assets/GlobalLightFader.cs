using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalLightFader : MonoBehaviour
{
    Transform player;
    Light2D globalLight;
    public float nzone = 10;
    public int zonesize = 100;

    [Range(0f,1f)]
    public float mininum;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        globalLight = GetComponent<Light2D>();
    }

    void FixedUpdate() {
        if(!player) return;

        int deepLevel = (int)(-player.position.y / zonesize);

        float intensity = (nzone-deepLevel)/nzone;
        if(intensity<mininum)
            intensity = mininum;

        globalLight.intensity = intensity;
    }
}
