using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{
    Light2D pointLight;
    Shop shop;

    private void Start() {
        pointLight = GetComponentInParent<Light2D>();
        shop = FindObjectOfType<Shop>();
    }

    public void SetLightRadius(float amount){
        pointLight.pointLightOuterRadius = amount;
        pointLight.pointLightInnerRadius = amount/2;
    }

}
