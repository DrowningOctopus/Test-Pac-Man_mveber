using System.Collections;
using UnityEngine;

public class CapsuleConsumable : MonoBehaviour, IConsumable
{
    int pointValue;
    ScoreManager scoreManager;

    // At the start of the game, fetch the score value of the consumable
    public void Start()
    {
        pointValue = 50;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void IsConsumed(GameObject capsuleConsumed)
    {
        capsuleConsumed.SetActive(false);
        UpdateScore(pointValue);
        Fear();
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreManager.IncrementScore(scoreToAdd);
    }

    private void Fear()
    {

    }
}
