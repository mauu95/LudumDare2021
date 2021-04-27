using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    PlayerEnergyManager player;
    public Healthbar bar;

    private void Start() {
        player = Player.instance.GetComponent<PlayerEnergyManager>();
        player.onEnergyChangedCallback += UpdateUI;
    }

    public void UpdateUI(){
        bar.SetHealth(player.energy);
    }
}
