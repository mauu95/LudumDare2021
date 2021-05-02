using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreManager : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    private Transform player;
    int maxScore = 0;

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

    public int GetMaxScore() {
        return maxScore;
    }
}
