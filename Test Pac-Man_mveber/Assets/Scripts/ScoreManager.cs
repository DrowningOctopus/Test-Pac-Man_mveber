using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

// This script manages the overall score of the player as well as the fear state status
public class ScoreManager : MonoBehaviour
{
    public int fearTime;                    // Number of seconds that the fear state lasts
    
    int playerScore;                        // Score of the player
    List<GhostController> listOfGhosts;     // List of all ghosts in the game

    bool fear;                              // Fear state status
    float fearTimer;                        // Time spent since the beginning of the current fear state
    int numberOfGhostsConsumedThisFear;     // Number of ghosts eaten since the current fear state began

    // Initializes the variables
    void Start()
    {
        playerScore = 0;
        fear = false;
        fearTimer = 0;
        numberOfGhostsConsumedThisFear = 0;

        NavMeshAgent[] tempListOfGhosts = FindObjectsOfType<NavMeshAgent>();
        listOfGhosts = new List<GhostController>();
        foreach (NavMeshAgent agent in tempListOfGhosts)
        {
            listOfGhosts.Add(agent.GetComponent(typeof(GhostController)) as GhostController);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Each frame we check if the fear state is active
        if (fear)
        {
            // Fear state should only last fearTime, and then we end the fear state
            fearTimer += Time.deltaTime;
            if (fearTimer >=  fearTime)
            {
                EndFearState();
            }
        }
    }

    // Increments the score with the requeted amount of points
    public void IncrementScore (int scoreToAdd)
    {
        playerScore += scoreToAdd;
    }

    // Increments the score with the requested amount of points for the ghosts eaten during the current fear state
    public void IncrementScoreForGhost(int scoreToAdd)
    {
        playerScore += scoreToAdd * (int)(Math.Pow(2, numberOfGhostsConsumedThisFear));
        numberOfGhostsConsumedThisFear += 1;
    }

    // Returns the fear state status
    public bool IsFear()
    {
        return fear;
    }

    // Updates the fear state status of this class and of the ghosts
    public void SetFear(bool newFearState)
    {
        fear = newFearState;
        UpdateGhostsState();
    }
    
    // Updates the state of each ghost depending on fear status
    void UpdateGhostsState()
    {
        foreach (GhostController ghost in listOfGhosts)
        {
            ghost.SetGhostFearState(fear);
        }
    }

    // Ends the fear state by reseting its status to false and reseting the fear timer
    void EndFearState()
    {
        SetFear(false);
        fearTimer = 0;
        numberOfGhostsConsumedThisFear = 0;
    }

    // The player loses a life for getting caught by the ghosts 
    public void LoseLife()
    {
        Debug.Log("YOU LOSE");
    }
}
