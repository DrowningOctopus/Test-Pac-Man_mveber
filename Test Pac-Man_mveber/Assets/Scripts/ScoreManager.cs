using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScoreManager : MonoBehaviour
{
    int playerScore;
    bool fear;
    float timer;
    List<IGhostController> listOfGhosts;
    
    // Start is called before the first frame update
    void Start()
    {
        fear = false;
        playerScore = 0;
        timer = 0;

        NavMeshAgent[] tempListOfGhosts = FindObjectsOfType<NavMeshAgent>();
        listOfGhosts = new List<IGhostController>();
        foreach (NavMeshAgent agent in tempListOfGhosts)
        {
            listOfGhosts.Add(agent.GetComponent(typeof(IGhostController)) as IGhostController);
        }
    }

    void Update()
    {
        if (fear)
        {
            timer += Time.deltaTime;
            if (timer >  4)
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

    public void SetFear(bool newFearState)
    {
        fear = newFearState;
        UpdateGhostsColor();
    }
    
    void UpdateGhostsColor()
    {
        foreach (IGhostController ghost in listOfGhosts)
        {
            if (fear)
            {
                ghost.SetFearColor();
            }
            else
            {
                ghost.SetRegularColor();
            }
        }
    }

    public bool IsFear()
    {
        return fear;
    }

    void EndFearState()
    {
        SetFear(false);
        timer = 0;
    }
}
