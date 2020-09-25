using System;
using UnityEngine;
using UnityEngine.AI;

public class GhostBlinky : GhostController
{
    public Vector3 restPosition;

    public override void ChasePacMan()
    {
        CharacterController pacman = FindObjectOfType<CharacterController>();
        GetComponent<NavMeshAgent>().SetDestination(pacman.gameObject.transform.position);
    }

    public override void Scatter()
    {
        GetComponent<NavMeshAgent>().SetDestination(restPosition);
    }

    public override void Frighten()
    {
        Scatter();
    }

    public override void SetGhostFearState(bool fearStatus)
    {
        SetGhostFear(fearStatus);
        Behaviour thisGhostConsumable = (Behaviour)this.GetComponentInChildren(typeof(GhostConsumable), true);
        thisGhostConsumable.enabled = fearStatus;
        if (fearStatus)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = ghostColor;
        }
    }
}
