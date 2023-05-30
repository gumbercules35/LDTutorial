using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int currentScore = 0;


    public int GetCurrentScore(){
        return currentScore;
    }

    public void IncrementScore(int scoreToAdd){
        currentScore += scoreToAdd;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
    }

    public void ResetScore(){
        currentScore = 0;
    }
}
