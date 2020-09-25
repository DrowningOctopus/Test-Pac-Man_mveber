using UnityEngine;
using UnityEngine.AI;

// Describes the generic behaviour of the ghosts
public abstract class GhostController : MonoBehaviour
{
    public Vector3 prisonCoordinates;       // Coordinates the ghosts are sent to when caught by Pac-Man during FEAR mode 
    public float jailDistance;             // Distance to the prison coordinated the ghost needs to reach to resume its chase
    
    Color ghostColor;                       // Color of the ghost
    ScoreManager scoreManager;              // Score and FEAR mode manager of the game
    bool ghostFear;                         // Fear status of this specific ghost
    bool goesToPrison;                      // Is the ghost eaten during FEAR mode to the prison yet ?

    // Behaviour of a ghost chasing Pac-Man
    public abstract void ChasePacMan();
    // Behaviour of a ghost not chasing Pac-Man
    public abstract void Scatter();
    // Behaviour of a ghost running away from Pac-Man
    public abstract void Frighten();

    // Initializes the variables
    void Start()
    {
        goesToPrison = false;
        ghostFear = false;
        scoreManager = FindObjectOfType<ScoreManager>();
        ghostColor = this.GetComponent<Renderer>().material.color;
    }

    // Determines ghost behaviour depending on the fear and prison status of the ghost
    void Update()
    {
        if (!ghostFear && !goesToPrison)
        {
            ChasePacMan();
        }
        else if (goesToPrison)
        {
            CheckIfReachedPrison();
        }
        else if (ghostFear)
        {
            Frighten();
        }
    }

    // Getter for the ghost fear status
    public bool GetGhostFear()
    {
        return ghostFear;
    }

    // Setter for the ghost fear status
    public void SetGhostFear(bool newGhostFearState)
    {
        ghostFear = newGhostFearState;
    }

    // Resets the fear status of the ghost and all linked aspects (switch to consumable, color)
    public void ResetGhostFearState(bool fearStatus)
    {
        ghostFear = fearStatus;
        Behaviour thisGhostConsumable = (Behaviour)this.GetComponentInChildren(typeof(GhostConsumable), true);
        thisGhostConsumable.enabled = fearStatus;
        if (fearStatus)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            ResetGhostColor();
        }
    }

    // On collision between a ghost and Pac-Man, check if Pac-Man got caught
    public void CatchPacMan()
    {
        if (!goesToPrison && !ghostFear)
        {
            Debug.Log("YOU GOT CAUGHT");
            scoreManager.LoseLife();
        }
    }

    // Sends the ghost to prison, turns it black and sets its going-to-prison status
    public void GoToPrison()
    {
        goesToPrison = true;
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        gameObject.GetComponent<NavMeshAgent>().SetDestination(prisonCoordinates);

    }

    // Determines if the ghost caught by Pac-Man during FEAR mode has reached the prison yet
    void CheckIfReachedPrison()
    {
        float distance = Vector3.Distance(prisonCoordinates, gameObject.transform.position);
        if (distance < jailDistance)
        {
            // Resets the going-to-prison status and color if that is the case
            goesToPrison = false;
            ResetGhostColor();
        }
    }

    // Resets the ghost color to its regular one
    public void ResetGhostColor()
    {
        gameObject.GetComponent<Renderer>().material.color = ghostColor;
    }
}
