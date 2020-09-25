using System.Collections;
using UnityEngine;

public interface IConsumable
{
    // Launches when the object is consumed by PacMan 
    void IsConsumed();
    // Updates the score
    void UpdateScore(int scoreToAdd);
}
