using System.Collections;
using UnityEngine;

public class FoodConsumable : Consumable
{
    int pointValue;
    ScoreManager scoreManager;

    // At the start of the game, fetch the score value of the consumable
    public void Start()
    {
        pointValue = 10;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // When the food is consumed, it is disabled from the scene then the score is updated
    public override void IsConsumed ()
    {
        this.gameObject.SetActive(false);
        UpdateScore(pointValue);
    }

    // Function to update the score via the ScoreManager
    public override void UpdateScore (int scoreToAdd)
    {
        scoreManager.IncrementScore(scoreToAdd);
    }
}
