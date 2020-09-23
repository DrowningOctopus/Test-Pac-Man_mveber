using System.Collections;
using UnityEngine;

public class FoodConsumable : MonoBehaviour, IConsumable
{
    int pointValue;
    ScoreManager scoreManager;

    // At the start of the game, fetch the score value of the consumable
    public void Start()
    {
        pointValue = 10;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void IsConsumed (GameObject foodConsumed)
    {
        foodConsumed.SetActive(false);
        UpdateScore(pointValue);
    }

    public void UpdateScore (int scoreToAdd)
    {
        scoreManager.IncrementScore(scoreToAdd);
    }
}
