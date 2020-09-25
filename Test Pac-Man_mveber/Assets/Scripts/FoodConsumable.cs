using System.Collections;
using UnityEngine;

// Describes specifically the behaviour of the smaller dots, aka the food
public class FoodConsumable : Consumable
{
    int pointValue;                 // Points awarded to the player upon consumption
    ScoreManager scoreManager;      // ScoreManager component of the game

    // Initializes the variables
    public void Start()
    {
        pointValue = 10;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Consumes the food by disabling it from the scene and updating the score
    public override void IsConsumed ()
    {
        UpdateScore(pointValue);
        this.gameObject.SetActive(false);
    }

    // Updates the score through the ScoreManager
    public override void UpdateScore (int scoreToAdd)
    {
        scoreManager.IncrementScore(scoreToAdd);
    }
}
