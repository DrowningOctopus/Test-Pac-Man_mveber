using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class ScoreManager : MonoBehaviour
{
    public int fearTime;
    
    int playerScore;
    List<GhostController> listOfGhosts;

    bool fear;
    float fearTimer;
    int numberOfGhostsConsumedThisFear;

    // Start is called before the first frame update
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
            // If so it should only last fearTime, and then we end the fear state
            fearTimer += Time.deltaTime;
            if (fearTimer >  fearTime)
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

    public void IncrementScoreForGhost(int scoreToAdd)
    {
        playerScore += 200 * (int)(Math.Pow(2, numberOfGhostsConsumedThisFear));
        Debug.Log(200 * (int)(Math.Pow(2, numberOfGhostsConsumedThisFear)));
        numberOfGhostsConsumedThisFear += 1;
    }

    // Returns the fear state status
    public bool IsFear()
    {
        return fear;
    }

    // Updates the fear state status, and the color of each ghosts accordingly
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
}
