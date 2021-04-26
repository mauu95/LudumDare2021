using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightManager : MonoBehaviour
{
    Light2D pointLight;
    Shop shop;
    PlayerEnergyManager energyManager;

    public float lightRadius = 0;
    public float maxRadius = 30;
    public int radiusUpgradeCounter;

    private float lightIntensity;

    private void Start() {
        pointLight = GetComponentInChildren<Light2D>();
        energyManager = GetComponent<PlayerEnergyManager>();
        shop = FindObjectOfType<Shop>();
        SetLightRadius(lightRadius);
        lightIntensity = pointLight.intensity;
    }

    public void SetLightRadius(float amount){
        pointLight.pointLightOuterRadius = amount;
        pointLight.pointLightInnerRadius = amount/2;
        lightRadius = amount;
    }

    public void IncreaseLightRadius(){
        SetLightRadius(lightRadius + SerieMonotonaDecrescente(radiusUpgradeCounter++));
        shop.UpdatePrice(radiusUpgradeCounter);
        energyManager.UpdateDecay(radiusUpgradeCounter);
    }

    public void SwitchOffPointLight(){
        pointLight.intensity = 0;
    }

    public void SwitchOnPointLight(){
        pointLight.intensity = lightIntensity;
    }

    public bool IsRadiusMaxxedOut(){
        return lightRadius > maxRadius;
    }

    private float SerieMonotonaDecrescente(int n){
        if (n < 1)
            return 4;
        else if (n < 3)
            return 2;
        else
            return 1;
    }

}
