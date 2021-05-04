using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    #region Singleton
    public static GameManager instance;
    private void Awake() {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public static bool IsGamePaused;

    [SerializeField] private GameObject pauseMenu;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (IsGamePaused) ResumeGame();
            else PauseGame();
            if (AudioManager.instance)
                AudioManager.instance.Play("Pause");
        }
    }

    public void PauseGame() {
        IsGamePaused = true;
        Time.timeScale = 0.0f;
        if (pauseMenu)
            pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        IsGamePaused = false;
        Time.timeScale = 1.0f;
        if (pauseMenu)
            pauseMenu.SetActive(false);
    }

    public void slowTime(bool yesno) {
        if (yesno)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void EndGame(){
        int maxScore = GetComponent<PlayerScoreManager>().GetMaxScore();
        if (ScoreManager.instance)
            ScoreManager.instance.GameEnd(maxScore);
    }

    public void QuitGame() => Application.Quit();
}