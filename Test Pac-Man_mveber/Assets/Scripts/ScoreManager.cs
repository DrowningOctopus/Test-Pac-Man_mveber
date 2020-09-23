﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int playerScore;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    // Increments the score with the requeted amount of points
    public void IncrementScore (int scoreToAdd)
    {
        playerScore += scoreToAdd;
        Debug.Log(playerScore);
    }
}