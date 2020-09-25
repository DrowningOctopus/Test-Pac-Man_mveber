using System;
using UnityEngine;
using UnityEngine.AI;

public class GhostBlinky : GhostController
{
    public Vector3 restPosition;
    public Material fearColor;

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
        ghostFear = fearStatus;
        if (fearStatus)
        {
            Behaviour thisGhostConsumable = (Behaviour)this.GetComponentInChildren(typeof(GhostConsumable), true);
            thisGhostConsumable.enabled = true;
            this.GetComponent<Renderer>().material = fearColor;
        }
        else
        {
            this.GetComponent<Renderer>().material = ghostColor;
        }
    }
}
