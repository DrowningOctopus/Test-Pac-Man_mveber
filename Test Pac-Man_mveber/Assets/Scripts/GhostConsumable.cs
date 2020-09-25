using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostConsumable : Consumable
{
    int pointValue;
    ScoreManager scoreManager;
    GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        pointValue = 200;
        scoreManager = FindObjectOfType<ScoreManager>();
        ghost = this.gameObject;
    }

    // When the ghost is consumed, its fear state is reset, the score is updated and the ghost goes to the prison, then the component is deactivated
    public override void IsConsumed()
    {
        ghost.GetComponent<GhostController>().SetGhostFearState(false);
        UpdateScore(pointValue);
        ghost.GetComponent<GhostController>().GoToPrison();
        ghost.GetComponent<GhostConsumable>().enabled = false;
    }

    // Updates the score via the ScoreManager
    public override void UpdateScore(int scoreToAdd)
    {
        scoreManager.IncrementScoreForGhost(scoreToAdd);
    }
}
