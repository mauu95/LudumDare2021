using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{
    Light2D pointLight;

    public int food;

    private void Start() {
        pointLight = GetComponentInParent<Light2D>();
    }

    public void SetLightRadius(float amount){
        pointLight.pointLightOuterRadius = amount;
        pointLight.pointLightInnerRadius = amount/2;
    }


}
