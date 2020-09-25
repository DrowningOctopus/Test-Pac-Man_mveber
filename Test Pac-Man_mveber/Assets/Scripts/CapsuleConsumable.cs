using System.Collections;
using UnityEngine;

// Describes specifically the behaviour of the bigger dots, aka the power capsules/pills
public class CapsuleConsumable : Consumable
{
    int pointValue;                 // Points awarded to the player upon consumption
    ScoreManager scoreManager;      // ScoreManager component of the game

    // Initializes the variables
    public void Start()
    {
        pointValue = 50;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Consumes the capsule by disabling it from the scene, updating the score and starting FEAR mode
    public override void IsConsumed()
    {
        UpdateScore(pointValue);
        this.gameObject.SetActive(false);
        Fear();
    }

    // Updates the score through the ScoreManager
    public override void UpdateScore(int scoreToAdd)
    {
        scoreManager.IncrementScore(scoreToAdd);
    }

    // Starts FEAR mode through the ScoreManager
    private void Fear()
    {
        scoreManager.SetFear(true);
    }
}
