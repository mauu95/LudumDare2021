using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HomeMenuHandler : MonoBehaviour {
    public TextMeshProUGUI score;
    public GameObject tryAgainLabel;
    // Start is called before the first frame update
    void Start() {
        if (ScoreManager.instance.lost) {
            score.text = "Highscore: " + ScoreManager.instance.score;
        } else {
            score.gameObject.SetActive(false);
            tryAgainLabel.SetActive(false);
        }
    }
}
