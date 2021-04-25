using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    PlayerLifeManager player;
    public Healthbar bar;

    private void Start() {
        player = PlayerMovement.instance.GetComponent<PlayerLifeManager>();
        player.onHealthChangedCallback += UpdateUI;
    }

    public void UpdateUI(){
        bar.SetHealth(player.health);
    }
}
