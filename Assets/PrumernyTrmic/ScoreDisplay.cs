using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        Score.Instance.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score) {
        scoreText.text = score.ToString();
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Score.Instance.ResetScore();
    }
}
