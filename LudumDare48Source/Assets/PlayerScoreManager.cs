using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreManager : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public HintUI hint;
    private Transform player;
    int maxScore = 0;
    private bool warned;
    
    private int lastScore;

    private void Start() {
        player = Player.instance.transform;
        InvokeRepeating("DigliDiAndareGiu", 60f, 180f);
    }

    void Update() {
        if(!player)
            return;
        float max = Mathf.Max(-player.position.y, maxScore);
        maxScore = (int)max;
        scoreText.text = "Max depth: " + maxScore;

        if(!warned && maxScore > 200){
            hint.SetText("Warning: SHARKS");
            warned = true;
        }
    }

    public int GetMaxScore() {
        return maxScore;
    }

    private void DigliDiAndareGiu(){
        if(lastScore != maxScore)
            hint.SetText("GO DOWN");
        
        lastScore = maxScore;
    }
}
