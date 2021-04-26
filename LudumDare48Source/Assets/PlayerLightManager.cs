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
    public float maxRadius = 30;
    public int radiusUpgradeCounter;

    private float lightIntensity;

    private void Start() {
        energyManager = GetComponent<PlayerEnergyManager>();
        shop = FindObjectOfType<Shop>();
        SetLightRadius(lightRadius);
        lightIntensity = mainLight.intensity;
    }

    public void SetLightRadius(float amount){
        mainLight.pointLightOuterRadius = amount;
        mainLight.pointLightInnerRadius = amount/2;
        lightRadius = amount;
    }

    public void IncreaseLightRadius(){
        SetLightRadius(lightRadius + SerieMonotonaDecrescente(radiusUpgradeCounter++));
        shop.UpdatePrice(radiusUpgradeCounter);
        energyManager.UpdateDecay(radiusUpgradeCounter);
    }

    public void SwitchOffPointLight(){
        mainLight.intensity = 0;
        secondaryLight.intensity = lightIntensity;
    }

    public void SwitchOnPointLight(){
        mainLight.intensity = lightIntensity;
        secondaryLight.intensity = 0;
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
