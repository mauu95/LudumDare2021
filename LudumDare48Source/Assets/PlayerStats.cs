using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{
    Light2D pointLight;
    Shop shop;

    float lightRadius = 0;

    private void Start() {
        pointLight = GetComponentInChildren<Light2D>();
        shop = FindObjectOfType<Shop>();
        SetLightRadius(lightRadius);
    }

    public void SetLightRadius(float amount){
        pointLight.pointLightOuterRadius = amount;
        pointLight.pointLightInnerRadius = amount/2;
        lightRadius = amount;
    }

    public void IncreaseLightRadius(){
        SetLightRadius(lightRadius + 5f);
    }

}
