using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private Score() { }

    private static Score instance = new Score();

    public static Score Instance => instance;

    //--------------------------- ^ singleton stuff

    public event Action<int> ScoreChanged;

    private int score;

    public int CurrentScore => score;

    public void AddScore(int amount) {
        score += amount;
        ScoreChanged?.Invoke(score);
    }

    public void ResetScore() {
        score = 0;
    }
}
