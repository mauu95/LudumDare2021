using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyManager : MonoBehaviour
{
    PlayerLightManager playerLight;
    PlayerLifeManager playerHealth;

    [Range(0,100)]
    public int energy;

    public int maxDecay = 4;
    public int decay;

    public delegate void OnEnergyChanged();
    public OnEnergyChanged onEnergyChangedCallback;

    void Start() {
        playerLight = GetComponent<PlayerLightManager>();
        playerHealth = GetComponent<PlayerLifeManager>();
        InvokeRepeating("ConsumeEnergy", 2f, 1f);
        InvokeRepeating("ConsumeHealth", 2f, 1f);
    }

    public void FillEnergy(){
        energy = 100;
        playerLight.SwitchOnPointLight();
    }

    public void AddEnergy(int amount){
        energy += amount;
        if(energy>100)
            energy=100;
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

    private void ConsumeHealth(){
        if(energy>0)return;
        playerHealth.TakeDamage(1);
    }

    public void UpdateDecay(int difficulty)
    {
        decay = difficulty;
        if (decay > maxDecay)
            decay = maxDecay;

    }




}
