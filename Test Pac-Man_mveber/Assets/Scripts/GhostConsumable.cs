using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Describes specifically the consumable behaviour of the ghosts during FEAR mode
public class GhostConsumable : Consumable
{
    int pointValue;                 // Basic points awarded to the player upon consumption
    ScoreManager scoreManager;      // ScoreManager component of the game

    // Initializes the variables
    void Start()
    {
        pointValue = 200;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Consumes the ghost reseting its fear status, sending it to prison, updating the score and starting FEAR modedisabling its Consumable aspect
    public override void IsConsumed()
    {
        UpdateScore(pointValue);
        GhostController ghost = gameObject.GetComponent<GhostController>();
        ghost.SetGhostFearState(false);
        ghost.GoToPrison();
        gameObject.GetComponent<GhostConsumable>().enabled = false;
    }

    // Updates the score via the ScoreManager
    public override void UpdateScore(int scoreToAdd)
    {
        scoreManager.IncrementScoreForGhost(scoreToAdd);
    }
}
