using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{
    Light2D pointLight;
    Shop shop;

    public float lightRadius = 0;
    public float maxRadius = 30;
    private int radiusUpgradeCounter;

    private float lightIntensity;

    private void Start() {
        pointLight = GetComponentInChildren<Light2D>();
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
        SetLightRadius(lightRadius + SerieMonotonaDecrescente(++radiusUpgradeCounter));
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
        float max = 6f;
        float min = 2f;
        float result = max - n;
        if(result > min)
            return result;
        else
            return min;
    }

}
