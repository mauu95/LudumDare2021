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
    private bool vaiGiuFigaWarned;
    
    private int lastScore;

    private void Start() {
        player = Player.instance.transform;
    }

    void Update() {
        if(!player)
            return;
        float max = Mathf.Max(-player.position.y, maxScore);
        maxScore = (int)max;
        scoreText.text = "Max depth: " + maxScore;
    }

    private void FixedUpdate() {
        if(!warned && maxScore > 200){
            hint.SetText("Warning: SHARKS");
            warned = true;
        }

        if(!vaiGiuFigaWarned && maxScore < 200 && Player.instance.level > 9){
            hint.SetText("It seems you are ready");
            hint.GiveHint("Go down...", 2f);
            hint.GiveHint("Go deep...", 4f);
            vaiGiuFigaWarned = true;
        }
    }

    public int GetMaxScore() {
        return maxScore;
    }
}
