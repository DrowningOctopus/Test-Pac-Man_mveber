using System.Collections;
using UnityEngine;

public class FoodConsumable : MonoBehaviour, IConsumable
{
    int pointValue;

    public void Start()
    {
        pointValue = 10;
    }

    public void IsConsumed (GameObject foodConsumed)
    {
        Debug.Log("Food Consumed, " + foodConsumed.name);
        UpdateScore(pointValue);
    }

    public void UpdateScore (int scoreToAdd)
    {

    }
}
