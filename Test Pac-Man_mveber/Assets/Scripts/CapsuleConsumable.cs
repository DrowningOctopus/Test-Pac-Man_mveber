using System.Collections;
using UnityEngine;

public class CapsuleConsumable : Consumable
{
    int pointValue;
    ScoreManager scoreManager;

    // At the start of the game, fetch the score value of the consumable
    public void Start()
    {
        pointValue = 50;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // When the capsule is consumed, it is disabled from the scene then the score is updated and the ghosts FEAR
    public override void IsConsumed()
    {
        this.gameObject.SetActive(false);
        UpdateScore(pointValue);
        Fear();
    }

    // Updates the score via the ScoreManager
    public override void UpdateScore(int scoreToAdd)
    {
        scoreManager.IncrementScore(scoreToAdd);
    }

    private void Fear()
    {
        scoreManager.SetFear(true);
    }
}
