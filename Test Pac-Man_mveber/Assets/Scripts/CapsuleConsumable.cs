using System.Collections;
using UnityEngine;

public class CapsuleConsumable : MonoBehaviour, IConsumable
{
    int pointValue;

    public void Start()
    {
        pointValue = 50;
    }

    public void IsConsumed(GameObject capsuleConsumed)
    {
        Debug.Log("Capsule consumed, " + capsuleConsumed.name);
        UpdateScore(pointValue);
        Fear();
    }

    public void UpdateScore(int scoreToAdd)
    {

    }

    private void Fear()
    {

    }
}
