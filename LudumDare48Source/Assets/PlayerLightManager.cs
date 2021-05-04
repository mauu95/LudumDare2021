using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightManager : MonoBehaviour
{
    public Light2D mainLight;
    public Light2D secondaryLight;

    Shop shop;
    PlayerEnergyManager energyManager;

    public float lightRadius = 0;
    private float lightIntensity;

    private void Start() {
        energyManager = GetComponent<PlayerEnergyManager>();
        shop = FindObjectOfType<Shop>();
        SetLightRadius(lightRadius);
        lightIntensity = mainLight.intensity;
    }

    public void SetLightRadiusBasedOnLevel(int level){
        float radius = level * 2;
        SetLightRadius(radius);
    }

    private void SetLightRadius(float amount){
        mainLight.pointLightOuterRadius = amount;
        mainLight.pointLightInnerRadius = amount/2;
        secondaryLight.pointLightOuterRadius = amount/3;
        lightRadius = amount;
    }

    public void SwitchOffPointLight(){
        mainLight.intensity = 0;
        secondaryLight.intensity = lightIntensity;
    }

    public void SwitchOnPointLight(){
        mainLight.intensity = lightIntensity;
        secondaryLight.intensity = 0;
    }

}
