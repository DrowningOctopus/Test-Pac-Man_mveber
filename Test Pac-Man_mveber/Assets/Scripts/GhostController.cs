using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GhostController : MonoBehaviour
{
    public Vector3 prisonCoordinates;
    bool goesToPrison;
    public bool ghostFear;

    public abstract void ChasePacMan();
    public abstract void Scatter();
    public abstract void Frighten();
    public abstract void SetGhostFearState(bool fearStatus);

    void Start()
    {
        prisonCoordinates = new Vector3(0f, 0.42f, 0.75f);
        goesToPrison = false;
        ghostFear = false;
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
    }

    void OnTriggerEnter(Collider otherObject)
    {
        // Here we get the GameObject that was collided
        GameObject collider = otherObject.gameObject;
        Debug.Log("Collision Occured : " + collider.name);
        if (goesToPrison & collider.name == "Prison")
        {
            goesToPrison = false;
            SetGhostFearState(false);
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
}
