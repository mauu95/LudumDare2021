using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreManager : MonoBehaviour {
    public TextMeshProUGUI scoreText;

    int maxScore = 0;

    // Update is called once per frame
    void Update() {
        float max = Mathf.Max(-transform.position.y, maxScore);
        if (max >= 200 && maxScore < 200) {
            MobManager.instance.AddSharks();
        }
        maxScore = (int)max;
        scoreText.text = "Max depth: " + maxScore;
    }

    public int GetMaxScore() {
        return maxScore;
    }
}
