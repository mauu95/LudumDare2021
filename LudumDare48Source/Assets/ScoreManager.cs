using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
    #region Singleton
    public static ScoreManager instance;
    private void Awake() {
        if (instance != null)
            return;
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }
    #endregion


    public bool lost = false;
    public int score = 0;

    public static void GameStart() {
        SceneManager.LoadScene("MainScene");
    }

    public void GameEnd(int score) {
        this.score = score;
        lost = true;
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
    }
}
