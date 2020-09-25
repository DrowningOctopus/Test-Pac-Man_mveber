using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GhostController : MonoBehaviour
{
    public Vector3 prisonCoordinates;
    public Color ghostColor;

    ScoreManager scoreManager;
    bool ghostFear;
    bool goesToPrison;

    public abstract void ChasePacMan();
    public abstract void Scatter();
    public abstract void Frighten();
    public abstract void SetGhostFearState(bool fearStatus);

    void Start()
    {
        goesToPrison = false;
        ghostFear = false;
        scoreManager = FindObjectOfType<ScoreManager>();
        ghostColor = this.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if (!ghostFear && !goesToPrison)
        {
            ChasePacMan();
        }
        else if (ghostFear)
        {
            Frighten();
        }
        else if (goesToPrison)
        {
            CheckIfReachedPrison();
        }
    }

    public bool GetGhostFear()
    {
        return ghostFear;
    }

    public void SetGhostFear(bool newGhostFearState)
    {
        ghostFear = newGhostFearState;
    }

    void CheckIfReachedPrison()
    {
        float distance = Vector3.Distance(prisonCoordinates, gameObject.transform.position);
        if (distance < 1)
        {
            goesToPrison = false;
            SetGhostFearState(false); // Ici ce n'est pas opti parce que je veux seulement changer la couleur des fantômes en normal
            Debug.Log("Ghost Reached Prison");
        }
    }

    public void GoToPrison()
    {
        Debug.Log("GO TO PRISON " + gameObject.name + ", Fear = " + ghostFear);
        goesToPrison = true;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        gameObject.GetComponent<NavMeshAgent>().SetDestination(prisonCoordinates);
        Debug.Log(gameObject.GetComponent<NavMeshAgent>().destination);
    }

    public void CatchPacMan()
    {
        if (!goesToPrison && !ghostFear)
        {
            Debug.Log("YOU GOT CAUGHT");
            scoreManager.LoseLife();
        }
    }
}
