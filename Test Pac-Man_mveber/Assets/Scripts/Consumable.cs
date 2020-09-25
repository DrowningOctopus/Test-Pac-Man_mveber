using System.Collections;
using UnityEngine;

// Class that describes the various consumables of the game
public abstract class Consumable : MonoBehaviour
{
    // Launches when the object is consumed by PacMan 
    public abstract void IsConsumed();
    
    // Updates the score
    public abstract void UpdateScore(int scoreToAdd);
}
