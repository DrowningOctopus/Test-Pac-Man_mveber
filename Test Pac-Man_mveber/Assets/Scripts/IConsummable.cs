using System.Collections;
using UnityEngine;

// T is an int representing the number of points earned when PacMan consumes the consummable
public interface IConsumable
{
    // action launched when the object is consumed by PacMan 
    void IsConsumed(GameObject consumable);
    // updating the score with T
    void UpdateScore(int scoreToAdd);
}
