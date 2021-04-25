using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyManager : MonoBehaviour
{
    public PlayerStats playerLight;

    [Range(0,100)]
    public int energy;

    public int decay;

    public delegate void OnEnergyChanged();
    public OnEnergyChanged onEnergyChangedCallback;

    void Start() {
        InvokeRepeating("ConsumeEnergy", 2f, 1f);
    }

    public void FillEnergy(){
        energy = 100;
        playerLight.SwitchOnPointLight();
    }

    private void ConsumeEnergy(){
        energy -= decay;
        if(energy < 0)
            energy = 0;
        
        if(onEnergyChangedCallback != null)
            onEnergyChangedCallback.Invoke();

        if(energy == 0){
            playerLight.SwitchOffPointLight();
        }
    }




}
