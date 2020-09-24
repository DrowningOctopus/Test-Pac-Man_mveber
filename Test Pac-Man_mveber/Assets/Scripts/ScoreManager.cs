using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScoreManager : MonoBehaviour
{
    public int fearTime;
    int playerScore;
    bool fear;
    float fearTimer;
    List<IGhostController> listOfGhosts;
    
    // Start is called before the first frame update
    void Start()
    {
        fear = false;
        playerScore = 0;
        fearTimer = 0;

        NavMeshAgent[] tempListOfGhosts = FindObjectsOfType<NavMeshAgent>();
        listOfGhosts = new List<IGhostController>();
        foreach (NavMeshAgent agent in tempListOfGhosts)
        {
            listOfGhosts.Add(agent.GetComponent(typeof(IGhostController)) as IGhostController);
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
        //Debug.Log(playerScore);
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
        foreach (IGhostController ghost in listOfGhosts)
        {
            ghost.SetGhostFearState(fear);
        }
    }

    // Ends the fear state by reseting its status to false and reseting the fear timer
    void EndFearState()
    {
        SetFear(false);
        fearTimer = 0;
    }
}
