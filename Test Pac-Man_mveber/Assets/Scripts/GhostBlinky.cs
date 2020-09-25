using System;
using UnityEngine;
using UnityEngine.AI;

// Describes specifically the moving behavior of the red ghost aka Blinky
public class GhostBlinky : GhostController
{
    public Vector3 restPosition;        // The position it tries to reach when not chasing Pac-Man

    // When chasing Pac-Man, Blinky tries to fing a path to Pac-Man's current position
    public override void ChasePacMan()
    {
        CharacterController pacman = FindObjectOfType<CharacterController>();
        GetComponent<NavMeshAgent>().SetDestination(pacman.gameObject.transform.position);
    }

    // When not chasing Pac-Man, Blinky tries to reach its rest position
    public override void Scatter()
    {
        GetComponent<NavMeshAgent>().SetDestination(restPosition);
    }

    // When running away from Pac-Man, Blinky scatters
    public override void Frighten()
    {
        Scatter();
    }
}
